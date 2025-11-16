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

namespace SistemaForms
{
    public partial class CrudVPlatos : Form
    {
        // Variable para almacenar el ID del producto seleccionado para edición/eliminación
        private int idProductoSeleccionado = 0;

        // Almacenar el índice de la fila seleccionada
        private int indiceFila = -1;
        public CrudVPlatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Asegúrate de validar si los campos de Stock y Costo son números válidos antes de crear el objeto
            if (!decimal.TryParse(txtCosto.Text, out decimal costo) || !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("El Costo y Stock deben ser números válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entProducto obj = new entProducto()
            {
                Nombre = txtNombre.Text,
                Costo = costo,
                Tipo = cboTipo.Text,
                Stock = stock
            };

            string Mensaje = string.Empty;
            int idGenerado = new logProducto().Registrar(obj, out Mensaje);

            if (idGenerado > 0)
            {
                MessageBox.Show("Producto registrado con éxito.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos(); // Recargar el DataGridView
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(Mensaje, "Error al Registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que llena el DataGridView con datos
        private void CargarProductos()
        {
            dgvData.Rows.Clear();
            List<entProducto> listaProductos = new logProducto().ListarProductos();

            foreach (entProducto item in listaProductos)
            {
                // 1. Agrega una nueva fila
                int fila = dgvData.Rows.Add();

                // 2. Asigna los valores a las celdas por el nombre de la columna
                // Esto es mucho más robusto que usar el índice o el Rows.Add(v1, v2,...)
                dgvData.Rows[fila].Cells["IdProducto"].Value = item.IdProducto;
                dgvData.Rows[fila].Cells["Nombre"].Value = item.Nombre;
                dgvData.Rows[fila].Cells["Stock"].Value = item.Stock;
                dgvData.Rows[fila].Cells["Costo"].Value = item.Costo;
                dgvData.Rows[fila].Cells["Tipo"].Value = item.Tipo;
            }
        }

        private void CrudVPlatos_Load(object sender, EventArgs e)
        {
            // 1. Cargar el ComboBox de Tipo
            cboTipo.Items.Add("Plato");
            cboTipo.Items.Add("Bebida");
            cboTipo.SelectedIndex = 0; // Seleccionar "Plato" por defecto

            // 2. Cargar el DataGridView
            CargarProductos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtStock.Text = "";
            txtCosto.Text = "";
            cboTipo.SelectedIndex = 0; // Vuelve a Plato o el primer elemento
            idProductoSeleccionado = 0;
            indiceFila = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validar si hay un producto seleccionado
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCosto.Text, out decimal costo) || !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("El Costo y Stock deben ser números válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entProducto obj = new entProducto()
            {
                IdProducto = idProductoSeleccionado,
                Nombre = txtNombre.Text,
                Costo = costo,
                Tipo = cboTipo.Text,
                Stock = stock
            };

            string Mensaje = string.Empty;
            bool resultado = new logProducto().Editar(obj, out Mensaje);

            if (resultado)
            {
                MessageBox.Show("Producto editado con éxito.", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos(); // Recargar el DataGridView
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(Mensaje, "Error al Editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceFila = e.RowIndex;
                DataGridViewRow row = dgvData.Rows[indiceFila];

                // Almacenar el ID y llenar los campos de texto
                idProductoSeleccionado = Convert.ToInt32(row.Cells["IdProducto"].Value);
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
                txtCosto.Text = row.Cells["Costo"].Value.ToString();
                cboTipo.Text = row.Cells["Tipo"].Value.ToString();
            }
        }
    }
}
