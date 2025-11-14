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
    public class datProveedor
    {
        // =================================================================================
        // 1. LISTAR PROVEEDORES
        // =================================================================================
        public List<entProveedor> ListarProveedor()
        {
            List<entProveedor> lista = new List<entProveedor>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                // Consulta que obtiene todos los campos de la tabla Proveedor
                string query = "SELECT IdProveedor, Nombre, Apellido, Telefono, DNI, Direccion, FechaRegistro FROM Proveedor";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        entProveedor p = new entProveedor
                        {
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"] != DBNull.Value ? dr["Apellido"].ToString() : string.Empty,
                            Telefono = dr["Telefono"] != DBNull.Value ? dr["Telefono"].ToString() : string.Empty,
                            DNI = dr["DNI"] != DBNull.Value ? dr["DNI"].ToString() : string.Empty,
                            Direccion = dr["Direccion"] != DBNull.Value ? dr["Direccion"].ToString() : string.Empty,
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                        };
                        lista.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar proveedores desde la base de datos: " + ex.Message);
                }
            }
            return lista;
        }

        // =================================================================================
        // 2. INSERTAR PROVEEDOR (REGISTRAR)
        // =================================================================================
        public bool InsertarProveedor(entProveedor proveedor)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = @"
                    INSERT INTO Proveedor (Nombre, Apellido, Telefono, DNI, Direccion) 
                    VALUES (@Nombre, @Apellido, @Telefono, @DNI, @Direccion)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                // Parámetros de la consulta
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", proveedor.Apellido ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DNI", proveedor.DNI ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion ?? (object)DBNull.Value);

                try
                {
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0; // Retorna true si se insertó al menos 1 fila
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar proveedor en la base de datos: " + ex.Message);
                }
            }
        }
    }
}
