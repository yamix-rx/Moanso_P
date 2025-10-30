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

namespace SistemaCocina
{
    public partial class MantenedorInsumo : Form
    {
        private int idInsumoSeleccionado = 0;
        public MantenedorInsumo()
        {
            InitializeComponent();
            listarInsumo();
            groupBoxDatos.Enabled = false;

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

                idInsumoSeleccionado = Convert.ToInt32(filaActual.Cells["idInsumo"].Value);
                txtNombre.Text = filaActual.Cells["nombreInsumo"].Value.ToString();
                txtUnidad.Text = filaActual.Cells["unidadMedida"].Value.ToString();
                txtCantidad.Text = filaActual.Cells["cantidad"].Value.ToString();
                txtPrecio.Text = filaActual.Cells["precioUnitario"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(filaActual.Cells["fecRegistro"].Value);
                chkActivo.Checked = Convert.ToBoolean(filaActual.Cells["estInsumo"].Value);

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
                entInsumo ins = new entInsumo
                {
                    nombreInsumo = txtNombre.Text.Trim(),
                    unidadMedida = txtUnidad.Text.Trim(),
                    cantidad = Convert.ToDecimal(txtCantidad.Text.Trim()),
                    precioUnitario = Convert.ToDecimal(txtPrecio.Text.Trim()),
                    fecRegistro = dtpFecha.Value,
                    estInsumo = chkActivo.Checked
                };

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

                entInsumo ins = new entInsumo
                {
                    idInsumo = idInsumoSeleccionado,
                    nombreInsumo = txtNombre.Text.Trim(),
                    unidadMedida = txtUnidad.Text.Trim(),
                    cantidad = Convert.ToDecimal(txtCantidad.Text.Trim()),
                    precioUnitario = Convert.ToDecimal(txtPrecio.Text.Trim()),
                    fecRegistro = dtpFecha.Value,
                    estInsumo = chkActivo.Checked
                };

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
            this.Close();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            groupBoxDatos.Enabled = true;
            LimpiarCampos();
        }
    }
}
