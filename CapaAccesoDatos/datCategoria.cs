using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class datCategoria
    {
        #region Singleton
        private static readonly datCategoria _instancia = new datCategoria();
        public static datCategoria Instancia
        {
            get { return _instancia; }
        }
        #endregion
        // --- Listar ---
        public List<entCategoria> ListarCategorias()
        {
            List<entCategoria> Lista = new List<entCategoria>();
            SqlConnection cn = null;

            try
            {
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Lista.Add(new entCategoria()
                    {
                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                        Nombre = dr["Nombre"].ToString()
                    });
                }
                dr.Close();
            }
            catch (Exception)
            {
                Lista = new List<entCategoria>();
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            return Lista;
        }

        // --- Registrar ---
        public int Registrar(entCategoria obj, out string Mensaje)
        {
            int idGenerado = 0;
            Mensaje = string.Empty;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spRegistrarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                idGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                Mensaje = ex.Message;
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            return idGenerado;
        }

        // --- Editar ---
        public bool Editar(entCategoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spEditarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            return respuesta;
        }

        // --- Eliminar ---
        public bool Eliminar(int idcategoria, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spEliminarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCategoria", idcategoria);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            return respuesta;
        }
    }
}
