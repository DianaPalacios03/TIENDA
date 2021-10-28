using BLTienda;
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
    public partial class formLogin : Form
    {
        SeguridadBL _seguridad;
        public formLogin()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario;
            string contraseña;

            usuario = textBox1.Text;
            contraseña = textBox2.Text;

            var resultado = _seguridad.Autorizar(usuario, contraseña);

            if (resultado == true)

                
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o conraseña incorrecta");
            }
}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
