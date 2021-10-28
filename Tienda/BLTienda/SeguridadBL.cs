using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class SeguridadBL
    {
        public bool Autorizar(string usuario, string contraseña)
        {
            if (usuario == "admin1" && contraseña == "123")
            {
                return true;
            }

            else
            {
                if (usuario == "admin2" && contraseña == "456")


            {
                return true;
            }

                return false;
        }
    }
}
}