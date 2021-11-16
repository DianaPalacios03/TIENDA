using System.ComponentModel;
using System.Data.Entity;

namespace BL.Tienda
{
    public class ProductosBL  //* Creacion de la clase Producto*//
    {
        Contexto _contexto;   //*Declarar la variable de tipo contexto*//
       public BindingList<Producto> ListaProductos { get; set; }  //*Permite realizar una lista de productos*//


        public ProductosBL()
        {
            _contexto = new Contexto();      //*Instanciamos la variable contexto*//
            ListaProductos = new BindingList<Producto>();

            //* Datos de prueba fueron eliminados*//
        }

        public BindingList<Producto> ObtenerProductos()
        {
            _contexto.Productos.Load();           //* Carga los productos*//
            ListaProductos = _contexto.Productos.Local.ToBindingList();   //*LLenamos la lista de productos*//

            return ListaProductos;
        }

        /*Creacion de metodo para el boton cancelar del formulario*/
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }


        //* Creacion de la funcion para guardar un nuevo producto*//
        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if(resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        //* Creacion de la funcion para agregar un nuevo producto*//
        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProductos.Add(nuevoProducto);
        }

        //* Creacion de la funcion para eliminar un producto*//
        public bool EliminarProducto(int id)
        {
            foreach (var Producto in ListaProductos)
            {
                if (Producto.Id == id)
                {
                    ListaProductos.Remove(Producto);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (producto == null)
            {
                resultado.Mensaje = "Agregue un producto válido.";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty(producto.Descripcion )== true) 
            {
                resultado.Mensaje = "Ingrese una descripcion.";
                resultado.Exitoso = false;
            }


            if (producto.Existencia  < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero.";
                resultado.Exitoso = false;
            }


            if (producto.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero.";
                resultado.Exitoso = false;
            }

            if (producto.CategoriaId == 0)
            {
                resultado.Mensaje = "Seleccione una categoria.";
                resultado.Exitoso = false;
            }


            return resultado;
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public byte[] Foto { get; set; }
        public bool Activo { get; set; }
     

        public  Producto()
        {
            Activo = true;
        }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
