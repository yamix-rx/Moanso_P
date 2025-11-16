using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCategoria
    {
        private datCategoria Datos = new datCategoria();

        public List<entCategoria> ListarCategorias()
        {
            return Datos.ListarCategorias();
        }

        public int Registrar(entCategoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre de la categoría no puede ser vacío.";
                return 0;
            }
            return Datos.Registrar(obj, out Mensaje);
        }

        public bool Editar(entCategoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría para editar.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre de la categoría no puede ser vacío.";
                return false;
            }
            return Datos.Editar(obj, out Mensaje);
        }

        public bool Eliminar(int idcategoria, out string Mensaje)
        {
            // Puedes añadir lógica de negocio si es necesario antes de eliminar
            return Datos.Eliminar(idcategoria, out Mensaje);
        }
    }
}
