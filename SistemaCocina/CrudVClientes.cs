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
    public partial class CrudVClientes : Form
    {
        public CrudVClientes()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuP = new MenuPrincipal();
            this.Hide();
            menuP.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void MantenedorClientes_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarClientes();
            btnEditar.Enabled = false; // Inicialmente no hay nada para editar
        }
        private void CargarClientes()
        {
            try
            {
                logCliente log = new logCliente();
                dgvClientes.DataSource = log.ListarCliente();

                // Ocultar el ID al usuario
                if (dgvClientes.Columns.Contains("IdCliente"))
                    dgvClientes.Columns["IdCliente"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error");
            }
        }

        // 2. Limpiar campos y resetear estado
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtDNI.Clear();
            dtpFechaRegistro.Value = DateTime.Now;

            // Resetea el tag de edición
            btnEditar.Tag = null;
            btnRegistrar.Enabled = true;
            btnEditar.Enabled = false; // Deshabilitado hasta seleccionar o hacer clic en Nuevo
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                entCliente nuevoCliente = new entCliente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellidos.Text,
                    DNI = txtDNI.Text,
                    FechaRegistro = dtpFechaRegistro.Value
                };

                if (new logCliente().InsertarCliente(nuevoCliente))
                {
                    MessageBox.Show("Cliente registrado con éxito.", "Éxito");
                    LimpiarCampos();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error");
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                // Guardamos el ID del cliente seleccionado
                btnEditar.Tag = Convert.ToInt32(fila.Cells["IdCliente"].Value);

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellido"].Value.ToString();
                txtDNI.Text = fila.Cells["DNI"].Value.ToString();
                // dtpFechaRegistro.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value); 

                btnRegistrar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Tag == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para editar.", "Advertencia");
                return;
            }

            try
            {
                entCliente clienteEditado = new entCliente
                {
                    IdCliente = (int)btnEditar.Tag,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellidos.Text,
                    DNI = txtDNI.Text,
                    FechaRegistro = dtpFechaRegistro.Value
                };

                if (new logCliente().ActualizarCliente(clienteEditado))
                {
                    MessageBox.Show("Cliente actualizado con éxito.", "Éxito");
                    LimpiarCampos();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message, "Error");
            }
        }
    }
}
