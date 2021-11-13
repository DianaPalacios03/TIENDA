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
using Win.Tienda;

namespace Win.Tienda
{
    public partial class FormClientes : Form
    {
        ClienteBL _cliente;


        public FormClientes()

        {
            InitializeComponent();

            _cliente = new ClienteBL();
            ListaClientesBindingSource.DataSource = _cliente.ObtenerClientes();
        }

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            ListaClientesBindingSource.EndEdit();
            var cliente = (Cliente)ListaClientesBindingSource.Current;

            var resultado = _cliente.GuardarCliente(cliente);

            if (resultado.Exitoso == true)
            {
                ListaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Cliente Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }
        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            AgregarClientebindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _cliente.EliminarCliente(id);

            if (resultado == true)
            {
                ListaClientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el Cliente");
            }
        }

        private void toolStripButtonCancelar_Click_1(object sender, EventArgs e)
        {
            _cliente.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

        private void AgregarClientebindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _cliente.AgregarCliente();
            ListaClientesBindingSource.MoveLast();
            DeshabilitarHabilitarBotones(false);
        }
    }
}




