using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class datVenta
    {
        private const string NOMBRE_ARCHIVO = "RegistroDeVentas.txt";
        private static readonly string RUTA_BASE = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string RUTA_ARCHIVO = Path.Combine(RUTA_BASE, NOMBRE_ARCHIVO);
        private const string SEPARADOR_VENTA = "=================================================";

        // =================================================================================
        // 1. REGISTRAR VENTA (Guardar en TXT)
        // =================================================================================
        public bool RegistrarVenta(entVenta venta, entCliente cliente)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // 1. Cabecera del Registro
                sb.AppendLine(SEPARADOR_VENTA); // Inicia con el separador
                sb.AppendLine($"FECHA REGISTRO: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                sb.AppendLine($"TIPO VENTA: {venta.TipoVenta}");
                sb.AppendLine($"TOTAL A PAGAR: {venta.TotalPagar:C}");
                sb.AppendLine("-------------------------------------------------");

                // 2. Datos del Cliente
                sb.AppendLine("CLIENTE:");
                sb.AppendLine($"  DNI: {cliente.DNI}");
                sb.AppendLine($"  Nombre: {cliente.Nombre} {cliente.Apellido}");
                sb.AppendLine("-------------------------------------------------");

                // 3. Detalles de la Venta (Productos)
                sb.AppendLine("DETALLE DEL PEDIDO:");

                int itemIndex = 1;
                foreach (var item in venta.DetalleVenta)
                {
                    // Asumimos que tienes la propiedad NombreProducto en entItemPedido para el TXT
                    string nombreProd = (item is entItemPedido itemPedido) ? itemPedido.NombreProducto : "Producto Desconocido";
                    string observacion = string.IsNullOrWhiteSpace(item.Observacion) ? "-" : item.Observacion;

                    sb.AppendLine($"  Item {itemIndex}: {nombreProd}");
                    sb.AppendLine($"    - Cantidad: {item.Cantidad}");
                    sb.AppendLine($"    - Precio Unitario: {item.Costo:C}");
                    sb.AppendLine($"    - Observación: {observacion}");
                    itemIndex++;
                }

                sb.AppendLine(SEPARADOR_VENTA); // Termina con el separador
                sb.AppendLine(""); // Línea vacía para separar registros

                // Escribir el contenido al archivo, agregándolo (append: true)
                File.AppendAllText(RUTA_ARCHIVO, sb.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la venta en el archivo de texto: " + ex.Message);
            }
        }

        // =================================================================================
        // 2. LISTAR VENTAS (Leer y Parsear TXT)
        // =================================================================================
        public DataTable ListarVentasRegistradas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdVenta", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("FechaVenta", typeof(DateTime));
            dt.Columns.Add("TotalPagar", typeof(decimal));
            dt.Columns.Add("TipoVenta", typeof(string));

            int idContador = 1;

            if (!File.Exists(RUTA_ARCHIVO))
            {
                return dt;
            }

            try
            {
                string[] lineas = File.ReadAllLines(RUTA_ARCHIVO);
                string clienteNombre = "N/A";
                DateTime fechaVenta = DateTime.MinValue;
                decimal totalPagar = 0;
                string tipoVenta = "N/A";

                foreach (string linea in lineas)
                {
                    if (linea.StartsWith(SEPARADOR_VENTA))
                    {
                        // 🚨 Si encontramos el separador después de una venta válida, la agregamos
                        if (totalPagar != 0)
                        {
                            dt.Rows.Add(idContador, clienteNombre, fechaVenta, totalPagar, tipoVenta);
                            idContador++;
                        }

                        // Reinicia los valores para la siguiente venta
                        clienteNombre = "N/A";
                        fechaVenta = DateTime.MinValue;
                        totalPagar = 0;
                        tipoVenta = "N/A";
                    }
                    else if (linea.StartsWith("FECHA REGISTRO:"))
                    {
                        string fechaStr = linea.Replace("FECHA REGISTRO: ", "").Trim();
                        DateTime.TryParse(fechaStr, out fechaVenta);
                    }
                    else if (linea.StartsWith("TIPO VENTA:"))
                    {
                        tipoVenta = linea.Replace("TIPO VENTA: ", "").Trim();
                    }
                    else if (linea.StartsWith("TOTAL A PAGAR:"))
                    {
                        // Quita la etiqueta y el símbolo de moneda para parsear correctamente
                        string totalStr = linea.Replace("TOTAL A PAGAR: ", "")
                                              .Replace("S/", "")
                                              .Replace("$", "")
                                              .Trim();
                        // Intentamos parsear usando la cultura actual para decimales
                        decimal.TryParse(totalStr, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out totalPagar);
                    }
                    else if (linea.StartsWith("  Nombre:"))
                    {
                        // 🚨 CORRECCIÓN: La línea usa DOS ESPACIOS antes de Nombre
                        clienteNombre = linea.Replace("  Nombre: ", "").Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer y analizar el archivo de ventas: " + ex.Message);
            }

            return dt;
        }

        // =================================================================================
        // 3. ANULAR VENTA (Eliminar del TXT)
        // =================================================================================
        public void AnularVenta(int idVentaAAnular)
        {
            if (!File.Exists(RUTA_ARCHIVO))
            {
                throw new FileNotFoundException("El archivo de ventas no existe para anular.");
            }

            string[] lineasOriginales = File.ReadAllLines(RUTA_ARCHIVO);
            List<string> nuevasLineas = new List<string>();

            int idContador = 1;
            bool dentroDeVentaAAnular = false;

            foreach (string linea in lineasOriginales)
            {
                if (linea.StartsWith(SEPARADOR_VENTA))
                {
                    if (idContador == idVentaAAnular)
                    {
                        dentroDeVentaAAnular = true; // Empieza a ignorar las líneas de esta venta
                    }
                    else if (dentroDeVentaAAnular)
                    {
                        dentroDeVentaAAnular = false; // Encuentra el final de la venta ignorada, se detiene
                        // No añadimos el separador final de la venta anulada
                    }
                    else
                    {
                        nuevasLineas.Add(linea); // Añade separador si no pertenece a la venta a anular
                    }

                    if (!dentroDeVentaAAnular)
                        idContador++; // Solo incrementa el contador si NO estamos dentro del bloque a anular
                }
                else if (!dentroDeVentaAAnular)
                {
                    // Si no estamos dentro de la venta a anular, guardamos la línea
                    nuevasLineas.Add(linea);
                }
            }

            // Escribir todas las líneas restantes de vuelta al archivo, sobrescribiendo el original
            File.WriteAllLines(RUTA_ARCHIVO, nuevasLineas);
        }
    }
}
