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
        // Se asume que la entidad Venta ya contiene el IdCliente, IdUsuario, TipoComprobante, Estado,
        // y el DetalleVenta con PrecioUnitario.
        public bool RegistrarVenta(entVenta venta)
        {
            // Usamos una transacción para asegurar que tanto la cabecera como el detalle se guarden
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                bool exito = false;

                try
                {
                    // 1. INSERTAR CABECERA DE VENTA (Tabla Venta)
                    // 🚨 AJUSTE: Incluir IdUsuario, TipoComprobante y Estado
                    string queryVenta = @"
                        INSERT INTO Venta (IdCliente, IdUsuario, FechaVenta, TipoComprobante, TipoVenta, TotalPagar, Estado) 
                        OUTPUT INSERTED.IdVenta
                        VALUES (@IdCliente, @IdUsuario, @FechaVenta, @TipoComprobante, @TipoVenta, @TotalPagar, @Estado)";

                    SqlCommand cmdVenta = new SqlCommand(queryVenta, cn, tr);
                    cmdVenta.CommandType = CommandType.Text;

                    cmdVenta.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                    cmdVenta.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario); // Requerido por la tabla
                    cmdVenta.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    cmdVenta.Parameters.AddWithValue("@TipoComprobante", venta.TipoComprobante); // Requerido por la tabla
                    cmdVenta.Parameters.AddWithValue("@TipoVenta", venta.TipoVenta);
                    cmdVenta.Parameters.AddWithValue("@TotalPagar", venta.TotalPagar);
                    cmdVenta.Parameters.AddWithValue("@Estado", venta.Estado); // Requerido por la tabla

                    // Ejecutamos y obtenemos el IdVenta generado (Identity)
                    int idVentaGenerado = (int)cmdVenta.ExecuteScalar();

                    // 2. INSERTAR DETALLE DE VENTA (Tabla DetalleVenta)
                    if (idVentaGenerado > 0)
                    {
                        foreach (var item in venta.DetalleVenta)
                        {
                            string queryDetalle = @"
                                INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Observacion)
                                VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Observacion)";

                            SqlCommand cmdDetalle = new SqlCommand(queryDetalle, cn, tr);
                            cmdDetalle.CommandType = CommandType.Text;

                            cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaGenerado);
                            cmdDetalle.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                            // 🚨 AJUSTE: Usar PrecioUnitario en lugar de Costo
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@Observacion", item.Observacion ?? (object)DBNull.Value); // Manejo de nulos

                            cmdDetalle.ExecuteNonQuery();
                        }

                        // Si todos los inserts son exitosos, CONFIRMAMOS la transacción
                        tr.Commit();
                        exito = true;
                    }
                    else
                    {
                        // Si la cabecera falló, deshacemos por si acaso
                        tr.Rollback();
                        throw new Exception("Error al obtener el IdVenta generado.");
                    }
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, DESHACEMOS la transacción
                    tr.Rollback();
                    throw new Exception("Error al registrar la venta en la base de datos: " + ex.Message);
                }
                return exito;
            }
        }

        // =================================================================================
        // 2. LISTAR VENTAS (Consultar SQL)
        // =================================================================================
        public DataTable ListarVentasRegistradas()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                // La consulta de ListarVentas es correcta, usa JOIN y las columnas principales
                string query = @"
                    SELECT 
                        v.IdVenta, 
                        c.Nombre + ' ' + c.Apellido AS Cliente, 
                        v.FechaVenta, 
                        v.TotalPagar, 
                        v.TipoVenta
                    FROM 
                        Venta v
                    INNER JOIN 
                        Cliente c ON v.IdCliente = c.IdCliente
                    ORDER BY 
                        v.FechaVenta DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
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
        public void AnularVenta(int idVentaAAnular)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();

                try
                {
                    // 1. ELIMINAR DETALLES: Es crucial eliminar primero los detalles 
                    string queryDetalle = "DELETE FROM DetalleVenta WHERE IdVenta = @IdVenta";
                    SqlCommand cmdDetalle = new SqlCommand(queryDetalle, cn, tr);
                    cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaAAnular);
                    cmdDetalle.ExecuteNonQuery();

                    // 2. ELIMINAR CABECERA
                    string queryVenta = "DELETE FROM Venta WHERE IdVenta = @IdVenta";
                    SqlCommand cmdVenta = new SqlCommand(queryVenta, cn, tr);
                    cmdVenta.Parameters.AddWithValue("@IdVenta", idVentaAAnular);

                    int filasAfectadas = cmdVenta.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        tr.Commit(); // Ambas operaciones fueron exitosas
                    }
                    else
                    {
                        tr.Rollback(); // No se encontró la cabecera
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