using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogica;
using System.IO;

namespace Yenci_parte
{
    public partial class Venta : Form
    {
        private int _IdClienteSeleccionado = 0;
        private List<entProducto> ListaTotalProductos;
        public List<entItemPedido> listaPedido = new List<entItemPedido>(); 
        public Venta()
        {
            InitializeComponent();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarPedidosRealizados();
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            // Captura la observación desde el TextBox (asumimos txtObservacionPlato)
            string observacion = txtObservacionPlato.Text;

            // --- Lógica del Plato ---
            if (cmbPlatos.SelectedIndex != -1 && int.TryParse(txtCantidadPlato.Text, out int cantPlato) && cantPlato > 0)
            {
                entProducto platoSeleccionado = (entProducto)cmbPlatos.SelectedItem;

                AgregarItem(
                    platoSeleccionado.IdProducto,
                    platoSeleccionado.Nombre,
                    // ✅ AJUSTE: Usamos Costo del producto como PrecioUnitario en el detalle de la venta.
                    platoSeleccionado.Costo,
                    cantPlato,
                    observacion
                );

                txtCantidadPlato.Clear();
                cmbPlatos.SelectedIndex = -1;
            }

            // --- Lógica de la Bebida ---
            if (cmbBebidas.SelectedIndex != -1 && int.TryParse(txtCantidadBebida.Text, out int cantBebida) && cantBebida > 0)
            {
                entProducto bebidaSeleccionada = (entProducto)cmbBebidas.SelectedItem;

                AgregarItem(
                    bebidaSeleccionada.IdProducto,
                    bebidaSeleccionada.Nombre,
                    // ✅ AJUSTE: Usamos Costo del producto como PrecioUnitario en el detalle de la venta.
                    bebidaSeleccionada.Costo,
                    cantBebida,
                    observacion
                );

                txtCantidadBebida.Clear();
                cmbBebidas.SelectedIndex = -1;
            }

            // Limpiamos la caja de observación después de intentar agregar.
            txtObservacionPlato.Clear();

            CalcularTotal();
        }
        private void AgregarItem(int id, string nombre, decimal precioUnitario, int cantidad, string observacion) // 🚨 MODIFICADO
        {// 1. Crear el objeto item
            entItemPedido nuevoItem = new entItemPedido
            {
                IdProducto = id,
                NombreProducto = nombre,
                // 🚨 CORRECCIÓN: Usamos el parámetro 'precioUnitario' (el que acabamos de recibir)
                PrecioUnitario = precioUnitario,
                Cantidad = cantidad,
                Observacion = observacion
            };

            // 2. Agregar a la lista que alimenta el DataGridView
            listaPedido.Add(nuevoItem);

            // 3. Refrescar el DataGridView
            dgvPedidoCliente.DataSource = null;
            dgvPedidoCliente.DataSource = listaPedido;

            txtCantidadPlato.Clear();
            txtObservacionPlato.Clear();
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            // Opción más limpia: calcular directamente desde la lista de entidades
            foreach (var item in listaPedido)
            {
                // Asegúrate de que entItemPedido tenga una propiedad Importe que calcule (Cantidad * PrecioUnitario)
                total += (item.Cantidad * item.PrecioUnitario);
            }

            /* // Si prefieres iterar sobre el DataGridView (menos recomendable):
            foreach (DataGridViewRow row in dgvPedidoCliente.Rows)
            {
                if (row.Cells["Importe"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Importe"].Value);
                }
            }
            */

            // Mostrar el resultado final
            txtTotalPagar.Text = total.ToString("N2");

            // Dispara la lógica de Vuelto (si ya la implementaste en el TextChanged de Monto Recibido)
            // Se asume que has llamado a este evento manualmente en el constructor o Venta_Load:
            // txtMontoRecibido_TextChanged(txtMontoRecibido, EventArgs.Empty);
        }

        private void CargarProductos()
        {
            try
            {
                ListaTotalProductos = new logProducto().ListarProductos();

                // Filtramos y llenamos Platos
                var platos = ListaTotalProductos.Where(p => p.Tipo == "Plato").ToList();
                cmbPlatos.DataSource = platos;
                cmbPlatos.DisplayMember = "Nombre";
                cmbPlatos.ValueMember = "IdProducto";
                cmbPlatos.SelectedIndex = -1;

                // Filtramos y llenamos Bebidas
                var bebidas = ListaTotalProductos.Where(p => p.Tipo == "Bebida").ToList();
                cmbBebidas.DataSource = bebidas;
                cmbBebidas.DisplayMember = "Nombre";
                cmbBebidas.ValueMember = "IdProducto";
                cmbBebidas.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el menú: " + ex.Message, "Error de BD");
            }
        }

        private void btnQuitarPedido_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay alguna fila seleccionada
            if (dgvPedidoCliente.SelectedRows.Count > 0)
            {
                int indiceFila = dgvPedidoCliente.SelectedRows[0].Index;

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de quitar este ítem del pedido?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // 4. Eliminar el ítem de la lista (nuestra fuente de datos)
                    listaPedido.RemoveAt(indiceFila);

                    // 5. Refrescar el DataGridView
                    dgvPedidoCliente.DataSource = null;
                    dgvPedidoCliente.DataSource = listaPedido;

                    // 6. Recalcular el total
                    CalcularTotal();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un ítem de la lista para quitar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal menuP = new MenuPrincipal();
            this.Hide();
            menuP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas del pedido y totales
            if (listaPedido.Count == 0)
            {
                MessageBox.Show("No hay ítems en el pedido actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🚨 VALIDACIÓN CRÍTICA: Se necesita el ID de un cliente en la BD
            if (_IdClienteSeleccionado <= 0)
            {
                MessageBox.Show("Debe buscar y seleccionar un cliente válido antes de registrar la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string totalText = string.IsNullOrWhiteSpace(txtTotalPagar.Text) ? "0.00" : txtTotalPagar.Text;

            if (!decimal.TryParse(totalText, out decimal totalPagarDecimal))
            {
                MessageBox.Show("El Total a Pagar no tiene un formato numérico válido.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Crear Entidad Venta
            entVenta venta = new entVenta
            {
                // 🚨 CAMPO OBLIGATORIO: Se usa el ID del cliente encontrado en la búsqueda.
                IdCliente = _IdClienteSeleccionado,

                // 🚨 CAMPOS REQUERIDOS POR LA TABLA VENTA (Ajusta según tu UI)
                IdUsuario = 1, // <<< AJUSTAR: Debe ser el ID del usuario LOUGEADO. Usamos 1 como placeholder.
                TipoComprobante = "Boleta", // <<< AJUSTAR: Tomar de un ComboBox/Control
                Estado = "Registrado", // <<< AJUSTAR: El estado inicial de la venta.

                FechaVenta = DateTime.Now,
                TotalPagar = totalPagarDecimal,
                TipoVenta = cmbTipoVenta.Text,
                DetalleVenta = listaPedido
            };

            // 3. Llamar a la Capa Lógica para el registro en SQL Server
            try
            {
                bool registrado = new logVenta().RegistrarVenta(venta); // Solo se pasa la entidad Venta

                if (registrado)
                {
                    MessageBox.Show("¡Venta registrada con éxito en la Base de Datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. LIMPIAR INTERFAZ
                    _IdClienteSeleccionado = 0; // Resetear ID Cliente
                    // txtDniBuscar.Clear(); // Limpia el campo DNI de búsqueda si existe
                    txtNombreCliente.Clear();
                    txtApellidosCliente.Clear();

                    // Limpieza de totales y pedido
                    listaPedido.Clear();
                    dgvPedidoCliente.DataSource = null;
                    txtTotalPagar.Text = "0.00";
                    // Limpiar campos de pago (Monto recibido, Vuelto)
                    // txtMontoRecibido.Clear(); 
                    // lblVuelto.Text = "0.00"; 

                    // 5. ACTUALIZAR LISTA DE PEDIDOS REALIZADOS
                    CargarPedidosRealizados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL REGISTRAR VENTA: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Función para cargar el DGV de la derecha (Pedidos Realizados)
        private void CargarPedidosRealizados()
        {
            try
            {
                // Esto ahora llama a la capa de datos que lee SQL Server (datVenta.ListarVentasRegistradas)
                dgvPedidosRealizados.DataSource = new logVenta().ListarVentasRegistradas();

                if (dgvPedidosRealizados.Columns.Contains("TotalPagar"))
                    dgvPedidosRealizados.Columns["TotalPagar"].HeaderText = "Total";
                if (dgvPedidosRealizados.Columns.Contains("FechaVenta"))
                    dgvPedidosRealizados.Columns["FechaVenta"].HeaderText = "Fecha";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de ventas: " + ex.Message, "Error de Sistema");
                dgvPedidosRealizados.DataSource = null;
            }
        }

        // EN EL ARCHIVO Venta.cs, dentro de la clase Venta : Form

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            decimal totalPagar = 0;
            decimal montoRecibido = 0;
            decimal vuelto = 0;

            if (!decimal.TryParse(txtTotalPagar.Text, out totalPagar))
            {
                return;
            }

            if (decimal.TryParse(((TextBox)sender).Text, out montoRecibido))
            {
                if (montoRecibido >= totalPagar)
                {
                    vuelto = montoRecibido - totalPagar;

                    lblVuelto.Text = vuelto.ToString("N2");
                    lblVuelto.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblVuelto.Text = "FALTA";
                    lblVuelto.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblVuelto.Text = "0.00";
                lblVuelto.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay alguna fila seleccionada en el DataGridView de la derecha
            if (dgvPedidosRealizados.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una venta para anular.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener el ID de la fila seleccionada
            int idVentaSeleccionada = Convert.ToInt32(dgvPedidosRealizados.CurrentRow.Cells["IdVenta"].Value);

            // 3. Confirmación de anulación
            DialogResult resultado = MessageBox.Show($"¿Está seguro de anular la Venta ID {idVentaSeleccionada}? Esta acción eliminará la venta de la Base de Datos.", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // 🚨 Llamada a la Lógica que ahora usa SQL DELETE
                    new logVenta().AnularVenta(idVentaSeleccionada);
                    MessageBox.Show($"Venta ID {idVentaSeleccionada} anulada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Recargar el DataGridView para reflejar el cambio
                    CargarPedidosRealizados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al anular la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscarCliente_Click(object sender, EventArgs e)
        {
            LimpiarDatosCliente();
            _IdClienteSeleccionado = 0; // Resetear ID antes de buscar

            string dniBuscado = txtDniBuscar.Text.Trim();

            try
            {
                // 1. Ejecutar la búsqueda
                logCliente log = new logCliente();
                entCliente clienteEncontrado = log.BuscarCliente(dniBuscado);

                if (clienteEncontrado != null)
                {
                    // 2. Mostrar datos encontrados
                    txtNombreCliente.Text = clienteEncontrado.Nombre;
                    txtApellidosCliente.Text = clienteEncontrado.Apellido;

                    // 🚨 CRUCIAL: Guardar el ID para usarlo al registrar la venta
                    _IdClienteSeleccionado = clienteEncontrado.IdCliente;

                    MessageBox.Show("Cliente encontrado. Nombre: " + clienteEncontrado.Nombre, "Búsqueda Exitosa");
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado. Debe registrarlo o verificar el DNI.", "Cliente no existe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de búsqueda: " + ex.Message, "Error");
            }
        }

        // Función auxiliar para limpiar los campos de datos del cliente
        private void LimpiarDatosCliente()
        {
            txtNombreCliente.Clear();
            txtApellidosCliente.Clear();
            // txtDniBuscar.Clear(); // Opcional: mantener el DNI para la siguiente búsqueda
        }
    }
}
