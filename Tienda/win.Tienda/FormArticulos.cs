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
    }
}
