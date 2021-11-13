using System.ComponentModel;
using System.Data.Entity;

namespace BL.Tienda
{
    public class CategoriaBL
    {
        
            Contexto _contexto;   //*Declarar la variable de tipo contexto*//
       public BindingList<Categoria> ListaCategorias { get; set; }  //*Permite realizar una lista de productos*//


        public CategoriaBL()
        {
            _contexto = new Contexto();      //*Instanciamos la variable contexto*//
            ListaCategorias = new BindingList<Categoria>();

            //* Datos de prueba fueron eliminados*//
        }

        public BindingList<Categoria> ObtenerCategorias()
        {
            _contexto.Categorias.Load();           //* Carga los productos*//
            ListaCategorias = _contexto.Categorias.Local.ToBindingList();   //*LLenamos la lista de productos*//

            return ListaCategorias;
        }

    }


    public class Categoria
    {

    public int Id { get; set; }
    public string  Descripcion { get; set; }
}
}
