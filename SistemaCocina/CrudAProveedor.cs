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
    public partial class CrudAProveedor : Form
    {
        private int idProveedorSeleccionado = 0; 
        public CrudAProveedor()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MenuPrincipal mp = new MenuPrincipal();
            this.Hide();
            mp.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                entProveedor prov = new entProveedor
                {
                    IdProveedor = idProveedorSeleccionado, 
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellidos.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    DNI = txtDNI.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    FechaRegistro = dtpFechaRegistro.Value
                };

                bool resultado;
                string mensaje;

                if (prov.IdProveedor == 0)
                {
                    // INSERTAR
                    resultado = logProveedor.Instancia.InsertarProveedor(prov);
                    mensaje = "Proveedor registrado correctamente.";
                }
                else
                {
                    // EDITAR
                    resultado = logProveedor.Instancia.EditarProveedor(prov);
                    mensaje = "✏️ Proveedor modificado correctamente.";
                }

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Sistema Cocina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operación fallida. No se actualizó ninguna fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la operación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimpiarCampos();
            groupBoxDatos.Enabled = false;
            btnRegistrar.Text = "Registrar"; 
            btnEditar.Enabled = true;
            listarProveedor();
        }

        public void listarProveedor()
        {
            try
            {
                dgvProveedores.DataSource = logProveedor.Instancia.ListarProveedor();
                dgvProveedores.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de proveedores: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MantenerdorProveedor_Load(object sender, EventArgs e)
        {
            //CargarProveedores();
            listarProveedor();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor de la lista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            groupBoxDatos.Enabled = true;
            btnRegistrar.Text = "Modificar";
            btnEditar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dgvProveedores.Rows[e.RowIndex];

                idProveedorSeleccionado = Convert.ToInt32(filaActual.Cells["IdProveedor"].Value);
                txtNombre.Text = filaActual.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = filaActual.Cells["Apellido"].Value.ToString();
                txtTelefono.Text = filaActual.Cells["Telefono"].Value.ToString();
                txtDNI.Text = filaActual.Cells["DNI"].Value.ToString();
                txtDireccion.Text = filaActual.Cells["Direccion"].Value.ToString();
                dtpFechaRegistro.Value = Convert.ToDateTime(filaActual.Cells["FechaRegistro"].Value);

                groupBoxDatos.Enabled = true;
            }
        }
    }
}
