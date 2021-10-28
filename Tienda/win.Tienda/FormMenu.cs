using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.Tienda
{
    public partial class FormMenu : System.Windows.Forms.Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();

        }

        private void Login()
        {
            var Formlogin = new formLogin();
            Formlogin.ShowDialog();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formArticulos = new FormArticulos();
            formArticulos.MdiParent = this;
            formArticulos.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Login();
        }
    }
}
