using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logPedido
    {
        #region Singleton
        private static readonly logPedido _instancia = new logPedido();
        public static logPedido Instancia
        {
            get { return _instancia; }
        }
        #endregion
        public List<entPedido> ListarPedidosPendientes()
        {
            return datPedido.Instancia.ListarPedidosPendientes();
        }
    }
}
