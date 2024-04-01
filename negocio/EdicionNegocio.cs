using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class EdicionNegocio
    {
        public List<Edicion> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Edicion> lista = new List<Edicion>();
            datos.setearConsulta("Select Id, Descripcion from TIPOSEDICION");

            datos.ejecutarLectura();

            try
            {
                while (datos.lector.Read())
                {
                    Edicion aux = new Edicion();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];

                    lista.Add(aux);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
    }
}
