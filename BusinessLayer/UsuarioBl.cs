using System;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class UsuarioBL
    {
        private UsuarioDAL objUsuarioDAL = new UsuarioDAL();

        public EUsuario ValidarUsuario(string usuario, string clave, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                mensaje = "El nombre de usuario no puede estar vacío.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                mensaje = "La contraseña no puede estar vacía.";
                return null;
            }

            return objUsuarioDAL.ValidarUsuario(usuario.Trim(), clave.Trim(), out mensaje);
        }

        public bool RegistrarUsuario(string usuario, string clave, int idRol, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                mensaje = "Debe ingresar un nombre de usuario.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                mensaje = "Debe ingresar una contraseña válida.";
                return false;
            }

            if (idRol <= 0)
            {
                mensaje = "Seleccione un rol válido para el usuario.";
                return false;
            }

            return objUsuarioDAL.RegistrarUsuario(usuario.Trim(), clave.Trim(), idRol, out mensaje);
        }
    }
}