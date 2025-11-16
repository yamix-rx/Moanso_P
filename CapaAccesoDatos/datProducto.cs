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
    public class datProducto
    {
        // ----------------------------------------------------
        // --- 1. Método para Listar Productos (DataGrid/Combos) ---
        // ----------------------------------------------------
        public List<entProducto> ListarProductos()
        {
            List<entProducto> Lista = new List<entProducto>();
            SqlConnection cn = null;

            try
            {
                // Reutilizando el código que proporcionaste para Listar
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarProducto", cn); // Usamos el SP de listado
                cmd.CommandType = CommandType.StoredProcedure; // Importante: Usamos SP

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entProducto P = new entProducto();
                    // Usamos el nombre de la columna para mayor claridad y seguridad
                    P.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                    P.Nombre = dr["Nombre"].ToString();
                    P.Costo = Convert.ToDecimal(dr["Costo"]);
                    P.Tipo = dr["Tipo"].ToString();
                    P.Stock = Convert.ToInt32(dr["Stock"]);

                    Lista.Add(P);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // En lugar de lanzar (throw), podrías devolver una lista vacía y registrar el error
                Lista = new List<entProducto>();
            }
            finally
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return Lista;
        }


        // ----------------------------------------------------
        // --- 2. Método para Registrar Producto ---
        // ----------------------------------------------------
        public int Registrar(entProducto obj, out string Mensaje)
        {
            int idGenerado = 0;
            Mensaje = string.Empty;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spRegistrarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("Costo", obj.Costo);
                cmd.Parameters.AddWithValue("Tipo", obj.Tipo);
                cmd.Parameters.AddWithValue("Stock", obj.Stock);

                // Parámetros de salida (definidos en el SP)
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                // Recuperar los valores de salida
                idGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                Mensaje = "Error en CapaAccesoDatos: " + ex.Message;
            }
            finally
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return idGenerado;
        }

        // ----------------------------------------------------
        // --- 3. Método para Editar Producto ---
        // ----------------------------------------------------
        public bool Editar(entProducto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spEditarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("Costo", obj.Costo);
                cmd.Parameters.AddWithValue("Tipo", obj.Tipo);
                cmd.Parameters.AddWithValue("Stock", obj.Stock);

                // Parámetros de salida (definidos en el SP)
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                // Recuperar los valores de salida
                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = "Error en CapaAccesoDatos: " + ex.Message;
            }
            finally
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return respuesta;
        }

        // ----------------------------------------------------
        // --- 4. Método para Eliminar Producto ---
        // ----------------------------------------------------
        public bool Eliminar(int idproducto, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spEliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetro de entrada
                cmd.Parameters.AddWithValue("IdProducto", idproducto);

                // Parámetros de salida (definidos en el SP)
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                // Recuperar los valores de salida
                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = "Error en CapaAccesoDatos: " + ex.Message;
            }
            finally
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return respuesta;
        }
    }
}
