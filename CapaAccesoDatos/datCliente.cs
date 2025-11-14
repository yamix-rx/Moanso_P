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
    public class datCliente
    {
        // Método para listar todos los clientes
        public List<entCliente> ListarCliente()
        {
            List<entCliente> lista = new List<entCliente>();

            // 🚨 CORRECCIÓN: Usamos tu Singleton de conexión
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                // Comando SQL para listar clientes
                SqlCommand cmd = new SqlCommand("SELECT IdCliente, Nombre, Apellido, DNI FROM Cliente", cn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        entCliente c = new entCliente
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                            Apellido = dr["Apellido"] != DBNull.Value ? dr["Apellido"].ToString() : string.Empty,
                            DNI = dr["DNI"] != DBNull.Value ? dr["DNI"].ToString() : string.Empty,
                            // Si la columna 'FechaRegistro' no existe en la tabla, se inicializa aquí.
                            FechaRegistro = DateTime.Now
                        };
                        lista.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    // Si el error persiste, revisa que las columnas en SQL coincidan
                    throw new Exception("Error al listar clientes desde la base de datos: " + ex.Message);
                }
            }
            return lista;
        }

        // Método para insertar un nuevo cliente
        public bool InsertarCliente(entCliente cliente)
        {
            // 🚨 CORRECCIÓN: Usamos tu Singleton de conexión
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = "INSERT INTO Cliente (Nombre, Apellido, DNI) VALUES (@Nombre, @Apellido, @DNI)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrWhiteSpace(cliente.Nombre) ? (object)DBNull.Value : cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", string.IsNullOrWhiteSpace(cliente.Apellido) ? (object)DBNull.Value : cliente.Apellido);
                cmd.Parameters.AddWithValue("@DNI", string.IsNullOrWhiteSpace(cliente.DNI) ? (object)DBNull.Value : cliente.DNI);

                try
                {
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar cliente en la base de datos: " + ex.Message);
                }
            }
        }

        public entCliente BuscarClientePorDNI(string dni)
        {
            entCliente cliente = null;

            // Asumimos que tienes el método Conectar() de tu Singleton de Conexion
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                // Nota: Asegúrate que tu tabla 'Cliente' tenga la columna 'DNI' y que no sea NULL
                string query = "SELECT IdCliente, Nombre, Apellido, DNI FROM Cliente WHERE DNI = @DNI";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                // El DNI es el parámetro de búsqueda
                cmd.Parameters.AddWithValue("@DNI", dni);

                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        // Si encuentra el registro, crea la entidad Cliente
                        cliente = new entCliente
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                            Apellido = dr["Apellido"] != DBNull.Value ? dr["Apellido"].ToString() : string.Empty,
                            DNI = dr["DNI"] != DBNull.Value ? dr["DNI"].ToString() : string.Empty,
                            FechaRegistro = DateTime.Now // Valor por defecto
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar cliente por DNI: " + ex.Message);
                }
            }
            return cliente; // Devuelve la entidad o null si no se encuentra
        }

        // Método para actualizar un cliente existente
        public bool ActualizarCliente(entCliente cliente)
        {
            // 🚨 CORRECCIÓN: Usamos tu Singleton de conexión
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = "UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI WHERE IdCliente = @IdCliente";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrWhiteSpace(cliente.Nombre) ? (object)DBNull.Value : cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", string.IsNullOrWhiteSpace(cliente.Apellido) ? (object)DBNull.Value : cliente.Apellido);
                cmd.Parameters.AddWithValue("@DNI", string.IsNullOrWhiteSpace(cliente.DNI) ? (object)DBNull.Value : cliente.DNI);

                try
                {
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar cliente en la base de datos: " + ex.Message);
                }
            }
        }

        // Método para eliminar un cliente
        public bool EliminarCliente(entCliente cliente)
        {
            // 🚨 CORRECCIÓN: Usamos tu Singleton de conexión
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                string query = "DELETE FROM Cliente WHERE IdCliente = @IdCliente";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);

                try
                {
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    return i > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar cliente en la base de datos: " + ex.Message);
                }
            }
        }
    }
}
