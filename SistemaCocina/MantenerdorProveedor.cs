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
    public partial class MantenerdorProveedor : Form
    {
        public MantenerdorProveedor()
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
            try
            {
                // 1. Crear la entidad a partir de los TextBox
                entProveedor nuevoProveedor = new entProveedor
                {
                    Nombre = txtNombre.Text, // Asume que txtNombre es el TextBox de Nombre
                    Apellido = txtApellidos.Text, // Asume txtApellidos
                    Telefono = txtTelefono.Text, // Asume txtTelefono
                    DNI = txtDNI.Text, // Asume txtDNI
                    Direccion = txtDireccion.Text, // Asume txtDireccion
                                                   // La FechaRegistro se establece por defecto en la base de datos
                };

                // 2. Llamar a la Capa Lógica
                bool exito = logProveedor.Instancia.InsertarProveedor(nuevoProveedor);

                if (exito)
                {
                    MessageBox.Show("Proveedor registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Limpiar y recargar
                    LimpiarCampos();
                    CargarProveedores();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MantenerdorProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                // 1. Obtener la lista desde la Capa Lógica
                List<entProveedor> lista = logProveedor.Instancia.ListarProveedor();

                // 2. Asignar al DataGridView
                dgvProveedores.DataSource = lista;

                // Opcional: Configurar nombres de columna si es necesario
                // dgvProveedores.Columns["IdProveedor"].Visible = false;
                // dgvProveedores.Columns["Nombre"].HeaderText = "Razón Social";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de proveedores: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para limpiar campos
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            // No hace falta limpiar el control de fecha
        }
    }
}
