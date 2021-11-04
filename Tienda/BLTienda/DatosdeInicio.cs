using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
  public  class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {

       protected override void  Seed (Contexto contexto)
       
        {
            
      
           var usuarioAdmin1 = new Usuario();
            usuarioAdmin1.Nombre = "admin1";
            usuarioAdmin1.Contraseña = "123";
            contexto.Usuarios.Add(usuarioAdmin1);

            var usuarioAdmin2 = new Usuario();
            usuarioAdmin2.Nombre = "admin2";
            usuarioAdmin2.Contraseña = "456";
            contexto.Usuarios.Add(usuarioAdmin2);


            var categoria1 = new Categoria();
            categoria1.Descripcion = "Ropa de dama";
          
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
           categoria2.Descripcion = "Ropa de caballero";

            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Ropa deportiva";

            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria3.Descripcion = "Ropa de niños";

            contexto.Categorias.Add(categoria4);


            var tipo1 = new Tipo();
            tipo1.Descripcion = "pantalones";

            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Accesorios";

            contexto.Tipos.Add(tipo2);




            base.Seed(contexto);
    }
}
}
