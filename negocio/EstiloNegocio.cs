using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EstiloNegocio
    {
        public List<Estilo> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Estilo> lista = new List<Estilo>();
            datos.setearConsulta("Select Id, Descripcion from ESTILOS");

            datos.ejecutarLectura();

            try
            {
                while (datos.lector.Read())
                {
                    Estilo aux = new Estilo();
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
