using System;
using CapaEntidad;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaAccesoDatos
{
    public class datPedido
    {
        #region Singleton
        private static readonly datPedido _instancia = new datPedido();
        public static datPedido Instancia
        {
            get { return _instancia; }
        }
        #endregion
        public List<entPedido> ListarPedidosPendientes()
        {
            List<entPedido> lista = new List<entPedido>();
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarPedidosPendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entPedido p = new entPedido();
                    p.IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"]);
                    p.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                    p.NombreProducto = dr["Plato"].ToString();
                    p.Cantidad = Convert.ToInt32(dr["Cantidad"]);

                    lista.Add(p);
                }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }

            return lista;
        }
    }
}
