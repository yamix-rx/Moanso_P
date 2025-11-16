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
    public partial class CrudACInsumo : Form
    {
        private int idInsumoSeleccionado = 0;
        public CrudACInsumo()
        {
            InitializeComponent();
            //listarInsumo();
            //groupBoxDatos.Enabled = false;

        }

        // --- Método de Carga de ComboBox (NUEVO) ---
        private void CargarCategoriasEnComboBox()
        {
            // Asegúrate de que tu proyecto tenga referencia a CapaLogica y CapaEntidad
            List<entCategoria> listaCategoria = new logCategoria().ListarCategorias();

            // Opción inicial: "Seleccione..." (IdCategoria = 0)
            listaCategoria.Insert(0, new entCategoria() { IdCategoria = 0, Nombre = "--- Seleccione Categoría ---" });

            // Asignación al ComboBox (Asumiendo que se llama cboCategoria)
            cboCategoria.DataSource = listaCategoria;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";
            cboCategoria.SelectedIndex = 0;
        }

        public void listarInsumo()
        {
            dgvInsumos.DataSource = logInsumo.Instancia.ListarInsumo();
            dgvInsumos.ClearSelection();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtUnidad.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            chkActivo.Checked = false;
            dtpFecha.Value = DateTime.Now;
            idInsumoSeleccionado = 0;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dgvInsumos.Rows[e.RowIndex];

                // ... (Carga de campos existentes) ...
                idInsumoSeleccionado = Convert.ToInt32(filaActual.Cells["idInsumo"].Value);
                txtNombre.Text = filaActual.Cells["nombreInsumo"].Value.ToString();
                txtUnidad.Text = filaActual.Cells["unidadMedida"].Value.ToString();
                txtCantidad.Text = filaActual.Cells["cantidad"].Value.ToString();
                txtPrecio.Text = filaActual.Cells["precioUnitario"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(filaActual.Cells["fecRegistro"].Value);
                chkActivo.Checked = Convert.ToBoolean(filaActual.Cells["estInsumo"].Value);

                // --- CÓDIGO CLAVE: SELECCIONAR CATEGORÍA EN COMBOBOX ---
                if (filaActual.Cells["IdCategoria"].Value != null)
                {
                    int idCat = Convert.ToInt32(filaActual.Cells["IdCategoria"].Value);
                    cboCategoria.SelectedValue = idCat;
                }
                else
                {
                    cboCategoria.SelectedValue = 0; // Seleccionar la opción "Seleccione Categoría"
                }

                groupBoxDatos.Enabled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener IdCategoria seleccionado y validar
                int idCategoriaSeleccionada = Convert.ToInt32(cboCategoria.SelectedValue);

                if (idCategoriaSeleccionada == 0)
                {
                    MessageBox.Show("Debe seleccionar una Categoría para el insumo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Crear la entidad Insumo
                entInsumo ins = new entInsumo
                {
                    nombreInsumo = txtNombre.Text.Trim(),
                    unidadMedida = txtUnidad.Text.Trim(),
                    cantidad = Convert.ToDecimal(txtCantidad.Text.Trim()),
                    precioUnitario = Convert.ToDecimal(txtPrecio.Text.Trim()),
                    fecRegistro = dtpFecha.Value,
                    estInsumo = chkActivo.Checked,

                    // --- AÑADIR IdCategoria ---
                    IdCategoria = idCategoriaSeleccionada
                };

                // ... (Llamada a logInsumo.Instancia.InsertarInsumo y mensaje) ...
                logInsumo.Instancia.InsertarInsumo(ins);
                MessageBox.Show("Insumo registrado correctamente.", "Sistema Cocina", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar insumo: " + ex.Message);
            }

            LimpiarCampos();
            groupBoxDatos.Enabled = false;
            listarInsumo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (idInsumoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un insumo para editar.");
                return;
            }

            groupBoxDatos.Enabled = true;
    
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idInsumoSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un insumo para modificar.");
                    return;
                }

                // 1. Obtener IdCategoria seleccionado y validar
                int idCategoriaSeleccionada = Convert.ToInt32(cboCategoria.SelectedValue);

                if (idCategoriaSeleccionada == 0)
                {
                    MessageBox.Show("Debe seleccionar una Categoría.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Crear la entidad Insumo
                entInsumo ins = new entInsumo
                {
                    idInsumo = idInsumoSeleccionado,
                    nombreInsumo = txtNombre.Text.Trim(),
                    unidadMedida = txtUnidad.Text.Trim(),
                    cantidad = Convert.ToDecimal(txtCantidad.Text.Trim()),
                    precioUnitario = Convert.ToDecimal(txtPrecio.Text.Trim()),
                    fecRegistro = dtpFecha.Value,
                    estInsumo = chkActivo.Checked,

                    // --- AÑADIR IdCategoria ---
                    IdCategoria = idCategoriaSeleccionada
                };

                // ... (Llamada a logInsumo.Instancia.EditarInsumo y mensaje) ...
                logInsumo.Instancia.EditarInsumo(ins);
                MessageBox.Show("✏️ Insumo modificado correctamente.", "Sistema Cocina", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar insumo: " + ex.Message);
            }

            LimpiarCampos();
            groupBoxDatos.Enabled = false;
            listarInsumo();

        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idInsumoSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un insumo para deshabilitar.");
                    return;
                }

                logInsumo.Instancia.DeshabilitarInsumo(idInsumoSeleccionado);
                MessageBox.Show("Insumo deshabilitado correctamente.", "Sistema Cocina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deshabilitar insumo: " + ex.Message);
            }

            LimpiarCampos();
            groupBoxDatos.Enabled = false;
            listarInsumo();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            groupBoxDatos.Enabled = false;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            this.Hide();
            menu.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            groupBoxDatos.Enabled = true;
            LimpiarCampos();
        }

        private void CrudACInsumo_Load(object sender, EventArgs e)
        {
            // Si lo quitaste del constructor, actívalo aquí
            listarInsumo();
            groupBoxDatos.Enabled = false;

            // CARGAR CATEGORÍAS
            CargarCategoriasEnComboBox();
        }
    }
}
