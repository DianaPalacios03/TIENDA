using BL.Tienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Tienda
{
    public partial class FormLogin : Form
    {

        SeguridadBL _seguridad;   //*Variable Local*//

        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();       //*Se inicializa la variable*//

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {


            string usuario;
            string contrasena;

            usuario = textBox1.Text;
            contrasena = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando...";
            Application.DoEvents();

            var resultado = _seguridad.Autorizar(usuario, contrasena);


            if (resultado != null)
            {
                Utilidades.NombreUsuario = resultado.Nombre;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }

            button1.Enabled = true;
            button1.Text = "Aceptar";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "" && e.KeyChar == (char) Keys.Enter)
            {
                textBox2.Focus();
            }
    }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "" &&  textBox2.Text != "" && e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }
    }
}


