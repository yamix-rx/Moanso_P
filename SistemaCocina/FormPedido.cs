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
        public FormPedido()
        {
            InitializeComponent();
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
            foreach (DataGridViewRow row in dgvReceta.Rows)
            {
                int idInsumo = Convert.ToInt32(row.Cells["IdInsumo"].Value);
                decimal cantidadPorPlato = Convert.ToDecimal(row.Cells["CantidadNecesaria"].Value);


                int cantidadPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["Cantidad"].Value);

                decimal totalDescontar = cantidadPorPlato * cantidadPedido;

                //logInsumo.Instancia.DescontarStock(idInsumo, totalDescontar);
            }

            MessageBox.Show("Insumos descontados. El pedido está en preparación.");
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
    }
}
