using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class SeguridadBL
    {
        Contexto _contexto;
        public BindingList<Usuario> ListaUsuarios { get; set; }

        public SeguridadBL()
        {
            _contexto = new Contexto();
            ListaUsuarios = new BindingList<Usuario>();
        }

        public BindingList<Usuario> ObtenerUsuarios()
        {
            _contexto.Usuarios.Load();
            ListaUsuarios = _contexto.Usuarios.Local.ToBindingList();

            return ListaUsuarios;
        }
        
        public bool Autorizar(string usuario, string contraseña)
        {
    var usuarios = _contexto.Usuarios.ToList();

    foreach (var usuarioDB in usuarios)
    {
        if (usuario == usuarioDB.Nombre && contraseña == usuarioDB.Contraseña)
        {
            return true;
        }
    }

    return false;
}
    }
}
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Contrasena { get; set; }
}














