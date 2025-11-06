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
    public class datVenta
    {
        public bool RegistrarVenta(entVenta venta, entCliente cliente)
        {
            bool registrado = false;
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlTransaction tr = null;

            try
            {
                cn.Open();
                tr = cn.BeginTransaction();

                // 1. REGISTRAR O BUSCAR CLIENTE
                int idCliente;

                SqlCommand cmdCliente = new SqlCommand("INSERT INTO Cliente (DNI, Nombre, Apellido) VALUES (@DNI, @Nom, @Ap)", cn, tr);
                cmdCliente.Parameters.AddWithValue("@DNI", cliente.DNI);
                cmdCliente.Parameters.AddWithValue("@Nom", cliente.Nombre);
                cmdCliente.Parameters.AddWithValue("@Ap", cliente.Apellido);
                cmdCliente.ExecuteNonQuery();

                // 🚨 SOLUCIÓN 1: Manejar la posible devolución de NULL en SCOPE_IDENTITY() para Cliente
                SqlCommand cmdIdCli = new SqlCommand("SELECT SCOPE_IDENTITY()", cn, tr);
                object resultadoIdCliente = cmdIdCli.ExecuteScalar();

                if (resultadoIdCliente == DBNull.Value || resultadoIdCliente == null)
                {
                    // Forzar excepción para que se ejecute Rollback
                    throw new Exception("Fallo en la inserción del Cliente. SCOPE_IDENTITY() devolvió NULL.");
                }
                idCliente = Convert.ToInt32(resultadoIdCliente);
                venta.IdCliente = idCliente;

                // 2. INSERTAR CABECERA DE VENTA
                SqlCommand cmdVenta = new SqlCommand("INSERT INTO Venta (IdCliente, IdUsuario, FechaVenta, TipoComprobante, TipoVenta, TotalPagar, Estado) VALUES (@IdCli, @IdUsr, @Fecha, @TipoComp, @TipoVenta, @Total, @Est); SELECT SCOPE_IDENTITY()", cn, tr);
                cmdVenta.Parameters.AddWithValue("@IdCli", venta.IdCliente);
                cmdVenta.Parameters.AddWithValue("@IdUsr", 1); // Asumimos ID de Usuario/Mozo fijo
                cmdVenta.Parameters.AddWithValue("@Fecha", venta.FechaVenta);
                cmdVenta.Parameters.AddWithValue("@TipoComp", "Ticket");
                cmdVenta.Parameters.AddWithValue("@TipoVenta", venta.TipoVenta);
                cmdVenta.Parameters.AddWithValue("@Total", venta.TotalPagar);
                cmdVenta.Parameters.AddWithValue("@Est", "Registrada");

                // 🚨 SOLUCIÓN 2: Manejar la posible devolución de NULL en SCOPE_IDENTITY() para Venta
                object resultadoIdVenta = cmdVenta.ExecuteScalar();

                if (resultadoIdVenta == DBNull.Value || resultadoIdVenta == null)
                {
                    // Forzar excepción para que se ejecute Rollback
                    throw new Exception("Fallo en la inserción de la Cabecera de Venta. SCOPE_IDENTITY() devolvió NULL.");
                }
                int idVenta = Convert.ToInt32(resultadoIdVenta);


                // 3. INSERTAR DETALLES DE VENTA (Iterando sobre entItemPedido)
                foreach (var item in venta.DetalleVenta)
                {
                    SqlCommand cmdDetalle = new SqlCommand("INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Observacion) VALUES (@IdVenta, @IdProd, @Cant, @Precio, @Obs)", cn, tr);
                    cmdDetalle.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmdDetalle.Parameters.AddWithValue("@IdProd", item.IdProducto);
                    cmdDetalle.Parameters.AddWithValue("@Cant", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@Precio", item.Costo);

                    // ✅ Manejo de Observación (ya corregido)
                    cmdDetalle.Parameters.AddWithValue("@Obs",
                        string.IsNullOrWhiteSpace(item.Observacion) ? (object)DBNull.Value : item.Observacion);

                    cmdDetalle.ExecuteNonQuery();
                }

                tr.Commit();
                registrado = true;
            }
            catch (Exception ex)
            {
                tr?.Rollback();
                // 🚨 MUESTRA LA EXCEPCIÓN DETALLADA SI SIGUE FALLANDO
                throw new Exception("Error al registrar la venta (Transacción revertida): " + ex.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            return registrado;
        }

        // Método para LISTAR las ventas registradas (Se mantiene sin cambios)
        public DataTable ListarVentasRegistradas()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = Conexion.Instancia.Conectar();

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    V.IdVenta, 
                    C.Nombre + ' ' + C.Apellido AS Cliente, 
                    V.FechaVenta, 
                    V.TotalPagar,
                    V.TipoVenta
                FROM Venta V
                INNER JOIN Cliente C ON V.IdCliente = C.IdCliente
                WHERE V.Estado = 'Registrada'
                ORDER BY V.FechaVenta DESC", cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ventas: " + ex.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open) cn.Close();
            }
            return dt;
        }
    }
}
