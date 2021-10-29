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
    public partial class FormArticulos : Form
    {
        ProductosBL _productos;
        public FormArticulos()
        {
            InitializeComponent();

            
            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();
        }

        private void FormArticulos_Load(object sender, EventArgs e)
        {

        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProductosBindingSource.EndEdit();
            var producto = (Producto)listaProductosBindingSource.Current;

            var resultado = _productos.GuardarProducto(producto);

            if (resultado.Exitoso== true)
            {
                listaProductosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Producto guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancealr.Visible = !valor;
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            if (idTextBox.Text != "")
            {

                var resultado = MessageBox.Show("Desea elimnar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                }

                var id = Convert.ToInt32(idTextBox.Text);
                Eliminar(id);
            }
      }
    

    private void Eliminar(int id)
        {

          
            var resultado = _productos.EliminarProducto(id);

            if (resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }
        }

        private void toolStripButtonCancealr_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}

