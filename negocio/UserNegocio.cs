using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using negocio;

namespace negocio
{
    public class UserNegocio
    {
        public bool Login(User Usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id,nombre, apellido, fechaNacimiento, admin, imagenPerfil from USERS where email = @email AND pass = @pass");
                datos.setearParametros("email", Usuario.Email);
                datos.setearParametros("pass", Usuario.Pass);
                datos.ejecutarLectura();

                while (datos.lector.Read())
                {
                    Usuario.Id = (int)datos.lector["id"];
                    if (datos.lector["nombre"] != System.DBNull.Value)
                        Usuario.Nombre = (string)datos.lector["nombre"];

                    if (datos.lector["apellido"] != System.DBNull.Value)
                        Usuario.Apellido = (string)datos.lector["apellido"];

                    if (datos.lector["fechaNacimiento"] != System.DBNull.Value)
                        Usuario.FechaNacimiento = (DateTime)datos.lector["fechaNacimiento"];

                    if ((bool)datos.lector["admin"])
                        Usuario.TipoUsuario = 1;
                    else Usuario.TipoUsuario = 0;

                    //if (datos.lector["ImagenPerfil"] != null)
                    //    Usuario.ImagenPerfil = (string)datos.lector["imagenPerfil"];
                    //else
                    //    Usuario.ImagenPerfil = "XXX";

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool SignUp(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (noExisteEmail(usuario))
                {

                    datos.setearConsulta("Insert into USERS (email, pass,admin) values (@email, @pass, 0)");
                    datos.setearParametros("email", usuario.Email);
                    datos.setearParametros("pass", usuario.Pass);
                    datos.ejecutarAccion();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool noExisteEmail(User Usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            User user = new User();

            try
            {
                datos.setearConsulta("Select id, email from USERS where email = @email");
                datos.setearParametros("email", Usuario.Email);
                datos.ejecutarLectura();
                while (datos.lector.Read())
                {
                    user.Id = (int)datos.lector["id"];
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static bool isAdmin(User user)
        {
            if (user.TipoUsuario == 1)
                return true;
            else return false;
        }

        public User buscarUser(string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            User user = new User();
            //try
            //{
            datos.setearConsulta("Select id, email, pass, nombre, apellido, fechaNacimiento, admin, imagenPerfil from USERS Where email = @email AND pass = @pass");
            datos.setearParametros("email", email);
            datos.setearParametros("pass", pass);
            datos.ejecutarLectura();

            user.Email = email;
            user.Pass = pass;

            try
            {
                while (datos.lector.Read())
                {
                    user.Id = (int)datos.lector["id"];
                    if (datos.lector["nombre"] != null)
                        user.Nombre = (string)datos.lector["nombre"];

                    if (datos.lector["apellido"] != null)
                        user.Apellido = (string)datos.lector["apellido"];

                    if (datos.lector["fechaNacimiento"] != null)
                        user.FechaNacimiento = (DateTime)datos.lector["fechaNacimiento"];

                    if ((bool)datos.lector["admin"])
                        user.TipoUsuario = 1;
                    else user.TipoUsuario = 0;

                    if (datos.lector["ImagenPerfil"] != null)
                        user.ImagenPerfil = (string)datos.lector["imagenPerfil"];
                }
            }
            catch (Exception)
            {

            }

            return user;


        }

        public void actualizarPerfil(User usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fecha Where id = @id");

            datos.setearParametros("nombre", usuario.Nombre);
            datos.setearParametros("apellido", usuario.Apellido);
            datos.setearParametros("id", usuario.Id);
            datos.setearParametros("fecha", usuario.FechaNacimiento);

            datos.ejecutarAccion();
        }



    }
}
