using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class datVenta
    {
        // =================================================================================
        // 1. REGISTRAR VENTA (Usando Transacción SQL)
        // =================================================================================
        // 🚨 CORRECCIÓN: Usar los nombres de columna reales: VentaID y ClienteID.
        public bool RegistrarVenta(entVenta venta)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                bool exito = false;

                try
                {
                    // 1. INSERTAR CABECERA DE VENTA (Tabla Venta)
                    // Se usa ClienteID y la salida es VentaID
                    string queryVenta = @"
                        INSERT INTO Venta (ClienteID, IdUsuario, FechaVenta, TipoComprobante, TipoVenta, TotalPagar, Estado) 
                        OUTPUT INSERTED.VentaID 
                        VALUES (@IdCliente, @IdUsuario, @FechaVenta, @TipoComprobante, @TipoVenta, @TotalPagar, @Estado)";

                    SqlCommand cmdVenta = new SqlCommand(queryVenta, cn, tr);
                    cmdVenta.CommandType = CommandType.Text;

                    // Mantenemos los nombres de parámetros C# para la entidad
                    cmdVenta.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                    cmdVenta.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                    cmdVenta.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    cmdVenta.Parameters.AddWithValue("@TipoComprobante", venta.TipoComprobante);
                    cmdVenta.Parameters.AddWithValue("@TipoVenta", venta.TipoVenta);
                    cmdVenta.Parameters.AddWithValue("@TotalPagar", venta.TotalPagar);
                    cmdVenta.Parameters.AddWithValue("@Estado", venta.Estado);

                    // Ejecutamos y obtenemos el VentaID generado (Identity)
                    int idVentaGenerado = (int)cmdVenta.ExecuteScalar();

                    // 2. INSERTAR DETALLE DE VENTA (Tabla DetalleVenta)
                    if (idVentaGenerado > 0)
                    {
                        foreach (var item in venta.DetalleVenta)
                        {
                            // Se asume que la FK en DetalleVenta es VentaID
                            string queryDetalle = @"
                                INSERT INTO DetalleVenta (VentaID, IdProducto, Cantidad, PrecioUnitario, Observacion)
                                VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Observacion)";

                            SqlCommand cmdDetalle = new SqlCommand(queryDetalle, cn, tr);
                            cmdDetalle.CommandType = CommandType.Text;

                            cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaGenerado); // Pasa el VentaID
                            cmdDetalle.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@Observacion", item.Observacion ?? (object)DBNull.Value);

                            cmdDetalle.ExecuteNonQuery();
                        }

                        tr.Commit();
                        exito = true;
                    }
                    else
                    {
                        tr.Rollback();
                        throw new Exception("Error al obtener el VentaID generado.");
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception("Error al registrar la venta en la base de datos: " + ex.Message);
                }
                return exito;
            }
        }

        // =================================================================================
        // 2. LISTAR VENTAS (Consultar SQL)
        // =================================================================================
        // 🚀 CORRECCIÓN APLICADA: Mapear VentaID y ClienteID a IdVenta e IdCliente usando AS.
        public DataTable ListarVentasRegistradas()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                // 🚀 CORRECCIÓN: Se limpia la consulta para eliminar cualquier espacio o tabulación oculta
                // y se usa la lógica: VentaID/ClienteID en Venta, y IdCliente en Cliente.
                string query = @"
                    SELECT
                        v.VentaID AS IdVenta,
                        v.ClienteID AS IdCliente, 
                        c.Nombre + ' ' + c.Apellido AS Cliente,
                        v.FechaVenta, 
                        v.TotalPagar, 
                        v.TipoVenta
                    FROM
                        Venta v
                    INNER JOIN
                        Cliente c ON v.ClienteID = c.IdCliente -- Asumiendo que la PK de Cliente es IdCliente
                    ORDER BY
                        v.FechaVenta DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    cn.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar ventas desde la base de datos: " + ex.Message);
                }
            }
            return dt;
        }

        // =================================================================================
        // 3. ANULAR VENTA (Eliminar de SQL)
        // =================================================================================
        // 🚨 CORRECCIÓN: Usar los nombres de columna reales: VentaID
        public void AnularVenta(int idVentaAAnular)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();

                try
                {
                    // 1. ELIMINAR DETALLES: Usar VentaID para el borrado
                    string queryDetalle = "DELETE FROM DetalleVenta WHERE VentaID = @IdVenta";
                    SqlCommand cmdDetalle = new SqlCommand(queryDetalle, cn, tr);
                    cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaAAnular);
                    cmdDetalle.ExecuteNonQuery();

                    // 2. ELIMINAR CABECERA: Usar VentaID para el borrado
                    string queryVenta = "DELETE FROM Venta WHERE VentaID = @IdVenta";
                    SqlCommand cmdVenta = new SqlCommand(queryVenta, cn, tr);
                    cmdVenta.Parameters.AddWithValue("@IdVenta", idVentaAAnular);

                    int filasAfectadas = cmdVenta.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        tr.Commit();
                    }
                    else
                    {
                        tr.Rollback();
                        throw new Exception("La venta a anular no fue encontrada.");
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception("Error al anular la venta en la base de datos: " + ex.Message);
                }
            }
        }
    }
}