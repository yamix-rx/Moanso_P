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
using Yenci_parte;

namespace SistemaCocina
{
    public partial class CrudACategorias : Form
    {
        private int idCategoriaSeleccionada = 0;
        private int indiceFila = -1;
        public CrudACategorias()
        {
            InitializeComponent();
        }

        private void CrudACategorias_Load(object sender, EventArgs e)
        {
            // Configura el DGV: Agrega las columnas IdCategoria (oculta) y Nombre
            CargarCategorias();
        }
        private void CargarCategorias()
        {
            dgvData.Rows.Clear();
            List<entCategoria> listaCategorias = new logCategoria().ListarCategorias();

            // Si usas Rows.Add(v1, v2, ...), verifica que dgvData tenga solo 2 columnas.
            foreach (entCategoria item in listaCategorias)
            {
                int fila = dgvData.Rows.Add();

                // Asumiendo que has creado las columnas en el DGV con estos nombres:
                dgvData.Rows[fila].Cells["IdCategoria"].Value = item.IdCategoria;
                dgvData.Rows[fila].Cells["Nombre"].Value = item.Nombre;
            }
        }
        // Método para limpiar los campos
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            idCategoriaSeleccionada = 0;
            indiceFila = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entCategoria obj = new entCategoria()
            {
                Nombre = txtNombre.Text
            };

            string Mensaje = string.Empty;
            int idGenerado = new logCategoria().Registrar(obj, out Mensaje);

            if (idGenerado > 0)
            {
                MessageBox.Show("Categoría registrada con éxito.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(Mensaje, "Error al Registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar una categoría para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entCategoria obj = new entCategoria()
            {
                IdCategoria = idCategoriaSeleccionada,
                Nombre = txtNombre.Text
            };

            string Mensaje = string.Empty;
            bool resultado = new logCategoria().Editar(obj, out Mensaje);

            if (resultado)
            {
                MessageBox.Show("Categoría editada con éxito.", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(Mensaje, "Error al Editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se hizo clic en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                indiceFila = e.RowIndex;
                DataGridViewRow row = dgvData.Rows[indiceFila];

                // 1. Almacena el IdCategoria (asumiendo que la columna se llama "IdCategoria")
                idCategoriaSeleccionada = Convert.ToInt32(row.Cells["IdCategoria"].Value);

                // 2. Muestra el Nombre en el TextBox (asumiendo que la columna se llama "Nombre")
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // 1. Validar que se haya seleccionado un producto
            if (idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar una categoría de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedir confirmación
            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar la categoría '{txtNombre.Text}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                string Mensaje = string.Empty;

                // 3. Llamar a la capa lógica para eliminar
                bool resultado = new logCategoria().Eliminar(idCategoriaSeleccionada, out Mensaje);

                if (resultado)
                {
                    MessageBox.Show("Categoría eliminada con éxito.", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias(); // Recargar el DataGridView
                    LimpiarCampos(); // Limpiar la selección y los TextBoxes
                }
                else
                {
                    // Mostrar el mensaje de error si la eliminación falla (ej. por dependencias)
                    MessageBox.Show(Mensaje, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            this.Hide();
            menu.Show();
        }
    }
}
