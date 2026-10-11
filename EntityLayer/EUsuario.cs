using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class EUsuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IdRol { get; set; }
        public string RolDescripcion { get; set; }
    }
}
