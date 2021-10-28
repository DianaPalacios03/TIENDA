using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class ProductosBL
    {
        public BindingList<Producto> ListaProductos { get; set; }
    public ProductosBL()
        {
            ListaProductos = new BindingList<Producto>();

            var producto1 = new Producto();
            producto1.Id = 1;
            producto1.Descripcion = "Camisa";
            producto1.Precio = 400;
            producto1.Existencia = 10;
            producto1.Activo = true;

            ListaProductos.Add(producto1);


            var producto2 = new Producto();
            producto2.Id = 2;
            producto2.Descripcion = "short";
            producto2.Precio = 500;
            producto2.Existencia = 5;
            producto2.Activo = true;

            ListaProductos.Add(producto2);


            var producto3 = new Producto();
            producto3.Id = 3;
            producto3.Descripcion = "Pantalon";
            producto3.Precio = 450;
            producto3.Existencia = 30;
            producto3.Activo = true;

            ListaProductos.Add(producto3);


        }
        public BindingList<Producto> ObtenerProductos()
        {
            return ListaProductos;
        }
    }
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio{ get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }
}
