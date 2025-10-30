using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logInsumo
    {
        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly logInsumo _instancia = new logInsumo();
        //privado para evitar la instanciación directa
        public static logInsumo Instancia
        {
            get
            {
                return logInsumo._instancia;
            }
        }
        #endregion singleton
        #region metodos
        //Listado
        public List<entInsumo> ListarInsumo()
        {
            return datInsumo.Instancia.ListarInsumo();
        }
        
        ///inserta
        public void InsertarInsumo(entInsumo ins)
        {
            datInsumo.Instancia.InsertarInsumo(ins);
        }
        //edita
        public void EditarInsumo(entInsumo ins)
        {
            datInsumo.Instancia.EditarInsumo(ins);
        }
   
        
        public void DeshabilitarInsumo(int idInsumo)
        {
            datInsumo.Instancia.DeshabilitarInsumo(idInsumo);
        }
        #endregion metodos

    }
}

