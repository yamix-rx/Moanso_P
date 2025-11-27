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
    public class datReceta
    {
        #region Singleton
        private static readonly datReceta _instancia = new datReceta();
        public static datReceta Instancia
        {
            get { return _instancia; }
        }
        #endregion

        // LISTAR RECETA (UN PRODUCTO Y SUS INSUMOS)
        public List<entReceta> ListarRecetaPorProducto(int idProducto)
        {
            List<entReceta> lista = new List<entReceta>();
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarRecetaPorProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entReceta obj = new entReceta();
                    obj.IdReceta = Convert.ToInt32(dr["IdReceta"]);
                    obj.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                    obj.IdInsumo = Convert.ToInt32(dr["IdInsumo"]);
                    obj.CantidadNecesaria = Convert.ToDecimal(dr["CantidadNecesaria"]);
                    obj.NombreProducto = dr["NombreProducto"].ToString();
                    obj.NombreInsumo = dr["NombreInsumo"].ToString();

                    lista.Add(obj);
                }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        // INSERTAR RECETA
        public void InsertarReceta(entReceta r)
        {
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarReceta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", r.IdProducto);
                cmd.Parameters.AddWithValue("@IdInsumo", r.IdInsumo);
                cmd.Parameters.AddWithValue("@CantidadNecesaria", r.CantidadNecesaria);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
        }

        public List<entDetalleReceta> ListarDetallesReceta(int idProducto)
        {
            List<entDetalleReceta> lista = new List<entDetalleReceta>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SP_ListarRecetaPorPlato", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new entDetalleReceta
                    {
                        IdInsumo = Convert.ToInt32(dr["IdInsumo"]),
                        InsumoNombre = dr["nombreInsumo"].ToString(), // ⚠️ Cuidado con la capitalización en nombreInsumo
                        CantidadNecesaria = Convert.ToDecimal(dr["CantidadNecesaria"]),
                        UnidadMedida = dr["unidadMedida"] != DBNull.Value ? dr["unidadMedida"].ToString() : string.Empty
                    });
                }
            }
            return lista;
        }
    }

}
