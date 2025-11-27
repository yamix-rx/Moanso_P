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
    public class datInsumo
    {
        #region Singleton
        // Patrón Singleton
        private static readonly datInsumo _instancia = new datInsumo();
        public static datInsumo Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region Métodos

        // ==============================
        // LISTAR INSUMOS
        // ==============================
        public List<entInsumo> ListarInsumo()
        {
            SqlCommand cmd = null;
            List<entInsumo> lista = new List<entInsumo>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                // Asegúrate que 'spListarInsumo' une con la tabla Categoria y devuelve IdCategoria y NombreCategoria
                cmd = new SqlCommand("spListarInsumo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entInsumo ins = new entInsumo();
                    ins.idInsumo = Convert.ToInt32(dr["idInsumo"]);
                    ins.nombreInsumo = dr["nombreInsumo"].ToString();
                    ins.unidadMedida = dr["unidadMedida"].ToString();
                    ins.cantidad = Convert.ToDecimal(dr["cantidad"]);
                    ins.precioUnitario = Convert.ToDecimal(dr["precioUnitario"]);
                    ins.estInsumo = Convert.ToBoolean(dr["estInsumo"]);
                    ins.fecRegistro = Convert.ToDateTime(dr["fecRegistro"]);

                    // --- NUEVOS CAMPOS LEÍDOS ---
                    // Se usa dr.IsDBNull para manejar insumos antiguos sin categoría
                    ins.IdCategoria = dr.IsDBNull(dr.GetOrdinal("IdCategoria")) ? 0 : Convert.ToInt32(dr["IdCategoria"]);
                    ins.NombreCategoria = dr.IsDBNull(dr.GetOrdinal("NombreCategoria")) ? "" : dr["NombreCategoria"].ToString();

                    lista.Add(ins);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null) cmd.Connection.Close();
            }
            return lista;
        }
        // ==============================
        // INSERTAR INSUMO
        // ==============================
        public bool InsertarInsumo(entInsumo ins)
        {
            SqlCommand cmd = null;
            bool insertado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarInsumo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreInsumo", ins.nombreInsumo);
                cmd.Parameters.AddWithValue("@unidadMedida", ins.unidadMedida);
                cmd.Parameters.AddWithValue("@cantidad", ins.cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", ins.precioUnitario);
                cmd.Parameters.AddWithValue("@estInsumo", ins.estInsumo);
                cmd.Parameters.AddWithValue("@fecRegistro", ins.fecRegistro);

                // --- PARÁMETRO FALTANTE CORREGIDO ---
                cmd.Parameters.AddWithValue("@IdCategoria", ins.IdCategoria);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                    insertado = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null) cmd.Connection.Close();
            }

            return insertado;
        }

        // ==============================
        // EDITAR INSUMO
        // ==============================
        public bool EditarInsumo(entInsumo ins)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarInsumo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idInsumo", ins.idInsumo);
                cmd.Parameters.AddWithValue("@nombreInsumo", ins.nombreInsumo);
                cmd.Parameters.AddWithValue("@unidadMedida", ins.unidadMedida);
                cmd.Parameters.AddWithValue("@cantidad", ins.cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", ins.precioUnitario);
                cmd.Parameters.AddWithValue("@estInsumo", ins.estInsumo);
                cmd.Parameters.AddWithValue("@fecRegistro", ins.fecRegistro);

                // --- PARÁMETRO FALTANTE CORREGIDO ---
                cmd.Parameters.AddWithValue("@IdCategoria", ins.IdCategoria);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                    editado = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null) cmd.Connection.Close();
            }

            return editado;
        }
        // EN CapaAccesoDatos/datInsumo.cs

        public bool DescontarStock(int idInsumo, decimal cantidadDescontar)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spDescontarStock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idInsumo", idInsumo); // Usamos el nombre de parámetro de tu SP
                cmd.Parameters.AddWithValue("@cantidadRestar", cantidadDescontar);
                cn.Open();

                // El ExecuteNonQuery devuelve el número de filas afectadas (debe ser 1)
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ==============================
        // DESHABILITAR INSUMO
        // ==============================
        public bool DeshabilitarInsumo(int idInsumo)
        {
            SqlCommand cmd = null;
            bool deshabilitado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitarInsumo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idInsumo", idInsumo);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                    deshabilitado = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return deshabilitado;
        }



        #endregion
    }
}

