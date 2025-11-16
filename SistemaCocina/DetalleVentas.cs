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
    public partial class DetalleVentas : Form
    {
        public DetalleVentas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuP = new MenuPrincipal();
            this.Hide();
            menuP.Show();
        }

        private void DetalleVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
