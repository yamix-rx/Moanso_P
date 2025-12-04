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
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spListarPedidosPendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        //  CORRECCIÓN: Leer los resultados por los ALIAS del SP, no por los nombres de la tabla
                        lista.Add(new entPedido
                        {
                            // Alias devueltos por el SP:
                            IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"]), 
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),       

                            Plato = dr["Plato"].ToString(),                     
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),

                            IdVenta = Convert.ToInt32(dr["IdVenta"]),            
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    // Propagación de error para diagnóstico
                    throw new Exception("Error al listar pedidos pendientes (Verifique el SP y el mapeo de columnas): " + ex.Message);
                }
            }
            return lista;
        }

        // 🚨 Agregamos el método para marcar como listo (Notificar Mozo) que usa el SP spMarcarPedidoListo
        public bool MarcarPedidoListo(int idVenta)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spMarcarPedidoListo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
