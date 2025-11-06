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
        // Método para cargar los productos al inicio (usado para llenar ComboBox)
        public List<entProducto> ListarProductos()
        {
            List<entProducto> Lista = new List<entProducto>();
            SqlConnection cn = null; // Declaramos la conexión fuera del try

            try
            {
                cn = Conexion.Instancia.Conectar(); // 1. Crea la conexión
                SqlCommand cmd = new SqlCommand("SELECT IdProducto, Nombre, Costo, Tipo, Stock FROM Producto", cn);
                cmd.CommandType = CommandType.Text;

                cn.Open(); // 2. 🚨 ¡ABRIR LA CONEXIÓN ES CRUCIAL!

                SqlDataReader dr = cmd.ExecuteReader(); // 3. Ejecut

                while (dr.Read())
                {
                    entProducto P = new entProducto();
                    P.IdProducto = dr.GetInt32(0);
                    P.Nombre = dr.GetString(1);
                    P.Costo = dr.GetDecimal(2);
                    P.Tipo = dr.GetString(3);
                    P.Stock = dr.GetInt32(4);

                    Lista.Add(P);
                }
                dr.Close(); // 4. Cerrar el DataReader
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // 4. Cerrar la conexión, solo si se logró crear (es decir, cn no es null)
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return Lista;
        }
    }
}
