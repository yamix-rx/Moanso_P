using CapaAccesoDatos;
using CapaEntidad;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProducto
    {
        // ====================================================================
        // 🚨 CAMBIO 1: IMPLEMENTACIÓN DEL SINGLETON
        // ====================================================================

        // Variable estática y de solo lectura para la instancia única
        private static readonly logProducto _instancia = new logProducto();

    

        // Propiedad estática para acceder a la instancia única
        public static logProducto Instancia
        {
            get { return _instancia; }
        }

        private datProducto Datos = new datProducto(); // Instancia de la DAL

        // 1. Método para Listar Productos
        public List<entProducto> ListarProductos()
        {
            try
            {
                return Datos.ListarProductos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos en la capa lógica: " + ex.Message);
            }
        }

        // 2. Método para Registrar Producto(con validaciones)
        public int Registrar(entProducto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // --- Validaciones de Negocio ---
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del plato/bebida no puede ser vacío.";
            }
            // ... (el resto de las validaciones se mantienen) ...
            else if (obj.Costo <= 0)
            {
                Mensaje = "El costo debe ser un valor positivo.";
            }
            else if (string.IsNullOrWhiteSpace(obj.Tipo))
            {
                Mensaje = "Debe seleccionar un tipo (Plato o Bebida).";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                // Si pasa las validaciones, llama a la capa de datos
                return Datos.Registrar(obj, out Mensaje);
            }
        }

        // 3. Método para Editar Producto (con validaciones)
        public bool Editar(entProducto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // --- Validaciones de Negocio ---
            if (obj.IdProducto == 0)
            {
                Mensaje = "Debe seleccionar un producto para editar.";
            }
            else if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del plato/bebida no puede ser vacío.";
            }
            else if (obj.Costo <= 0)
            {
                Mensaje = "El costo debe ser un valor positivo.";
            }
            else if (string.IsNullOrWhiteSpace(obj.Tipo))
            {
                Mensaje = "Debe seleccionar un tipo (Plato o Bebida).";
            }

            if (Mensaje != string.Empty)
            {
                return false; // No se edita si hay errores de validación
            }
            else
            {
                // Si pasa las validaciones, llama a la capa de datos
                return Datos.Editar(obj, out Mensaje);
            }
        }

        // 4. Método para Eliminar Producto
        public bool Eliminar(int idproducto, out string Mensaje)
        {
            // Podrías añadir validaciones aquí, aunque gran parte de la lógica de restricción
            // (asociación a ventas) ya está en el Procedimiento Almacenado.
            return Datos.Eliminar(idproducto, out Mensaje);
        }
    }
}
