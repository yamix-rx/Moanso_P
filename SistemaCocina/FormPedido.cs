using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Yenci_parte
{
    public partial class FormPedido : Form
    {
        // 🚨 Nueva variable global para almacenar todos los productos
        private List<entProducto> ListaTotalProductos;
        public FormPedido()
        {
            InitializeComponent();
            // 1. Cargar la lista completa de productos
            ListaTotalProductos = logProducto.Instancia.ListarProductos();
            CargarPedidos();
        }
        void CargarPedidos()
        {
            dgvPedidos.DataSource = logPedido.Instancia.ListarPedidosPendientes();
        }

        private void FormPedido_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizarPedidos_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void btnPreparar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un pedido pendiente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVenta = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdVenta"].Value);
            int idProducto = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdProducto"].Value);
            int cantidadPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["Cantidad"].Value);
            entProducto productoSeleccionado = ListaTotalProductos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (MessageBox.Show($"¿Confirmar que el Pedido N° {idVenta} está preparado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // ==========================================================
            // LÓGICA CONSOLIDADA (Platos vs. Bebidas)
            // ==========================================================
            try
            {
                if (productoSeleccionado != null && productoSeleccionado.Tipo == "Bebida")
                {
                    // 🚀 CASO BEBIDA: Solo cambia el estado. El descuento de stock de Bebidas ya se maneja en el registro de la Venta.
                    if (logInsumo.Instancia.MarcarPedidoListo(idVenta))
                    {
                        MessageBox.Show($"Bebida marcada como lista. Mozo notificado.", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el estado de la bebida.", "Fallo de BD");
                    }
                }
                else // CASO PLATO: Requiere descuento de insumos.
                {
                    if (dgvReceta.Rows.Count == 0)
                    {
                        MessageBox.Show("Advertencia: El plato requiere receta y no se cargaron insumos. Imposible procesar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool exitoDescuento = true;

                    // 1. Descuento de Insumos (Iteramos sobre la receta cargada)
                    foreach (DataGridViewRow row in dgvReceta.Rows)
                    {
                        int idInsumo = Convert.ToInt32(row.Cells["IdInsumo"].Value);
                        decimal cantidadPorPlato = Convert.ToDecimal(row.Cells["CantidadNecesaria"].Value);
                        decimal totalDescontar = cantidadPorPlato * cantidadPedido;

                        if (!logInsumo.Instancia.DescontarStock(idInsumo, totalDescontar))
                        {
                            exitoDescuento = false;
                            string insumoFaltante = row.Cells["InsumoNombre"].Value.ToString();

                            MessageBox.Show($"ERROR: Stock insuficiente para el insumo: {insumoFaltante}. No se descontó el pedido.", "Fallo de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break; // Detenemos la preparación
                        }
                    }

                    // 2. Si el descuento fue exitoso, marcamos como LISTO
                    if (exitoDescuento)
                    {
                        if (logInsumo.Instancia.MarcarPedidoListo(idVenta))
                        {
                            MessageBox.Show($"Pedido N° {idVenta} preparado, insumos descontados y Mozo notificado.", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el estado del pedido.", "Fallo de BD");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el pedido: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CargarPedidos(); // Siempre recargar para ver los cambios de estado/stock
            }
        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pedido listo. El mozo ha sido notificado.");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            this.Hide();
            menu.Show();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPedidos.CurrentRow != null)
            {
                // Limpiar el DGV de Receta
                dgvReceta.DataSource = null;

                try
                {
                    // 1. Obtener ID y Nombre
                    int idProducto = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdProducto"].Value);
                    string nombrePlato = dgvPedidos.CurrentRow.Cells["Plato"].Value.ToString();

                    // 2. Determinar el tipo de producto
                    entProducto productoSeleccionado = ListaTotalProductos.FirstOrDefault(p => p.IdProducto == idProducto);

                    if (productoSeleccionado != null && productoSeleccionado.Tipo == "Bebida")
                    {
                        // 🚀 CASO BEBIDA: Limpia la grilla de receta y avisa.
                        // Asumo que tienes un control (Label o TextBox) para mostrar el plato seleccionado
                        // Si tienes un TextBox, debes darle un nombre, por ejemplo: txtPlatoSeleccionado
                        // Reemplaza 'txtPlatoSeleccionado' con el nombre de tu control si es diferente.
                        // Si no tienes uno, simplemente omite la siguiente línea.
                        // txtPlatoSeleccionado.Text = $"Plato Seleccionado: {nombrePlato} (BEBIDA - SIN RECETA)"; 

                        // Asegurar que la grilla de receta esté vacía
                        dgvReceta.Rows.Clear();
                        dgvReceta.DataSource = null;
                        return; // Salir, no hay más que hacer para una bebida
                    }

                    // Si es 'Plato', procedemos con la carga de receta...
                    // txtPlatoSeleccionado.Text = $"Plato Seleccionado: {nombrePlato}"; 

                    // 3. Cargar los detalles de la receta (Insumos)
                    List<entDetalleReceta> receta = logReceta.Instancia.ListarDetallesReceta(idProducto);

                    // 4. Mostrar la receta en el dgvReceta
                    dgvReceta.DataSource = receta;

                    // ... (Configuración visual se mantiene) ...
                    if (dgvReceta.Columns.Contains("InsumoNombre"))
                        dgvReceta.Columns["InsumoNombre"].HeaderText = "Insumo";
                    if (dgvReceta.Columns.Contains("CantidadNecesaria"))
                        dgvReceta.Columns["CantidadNecesaria"].HeaderText = "Cant. x Plato";
                    if (dgvReceta.Columns.Contains("IdInsumo"))
                        dgvReceta.Columns["IdInsumo"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la receta: " + ex.Message, "Error Crítico");
                }
            }
        }


    }
}
