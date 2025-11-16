
using SistemaCocina;
using SistemaForms;
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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Venta vt = new Venta();
            this.Hide();
            vt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Form1 Mi = new Form1();
            Mi.ShowDialog();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CrudVClientes CL = new CrudVClientes();
            this.Hide();
            CL.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MantenerdorProveedor log = new MantenerdorProveedor();
            this.Hide();
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPedido pc = new FormPedido();
            this.Hide(); 
            pc.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CrudVPlatos cp = new CrudVPlatos();
            this.Hide();
            cp.Show();
        }
    }
}
