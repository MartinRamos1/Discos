using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DiscoNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Disco> Listar()
        {
            List<Disco> lista = new List<Disco>();


            datos.setearConsulta("Select D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion Estilo, T.Descripcion Edición, T.Id idEdicion, E.Id idEstilo from DISCOS D, ESTILOS E, TIPOSEDICION T Where D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id");
            datos.ejecutarLectura();

            try
            {
                while (datos.lector.Read()) { 

                    Disco aux = new Disco();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Titulo = (string)datos.lector["Titulo"];
                    aux.FechaLanzamiento = new DateTime();
                    aux.FechaLanzamiento = (DateTime)datos.lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)datos.lector["UrlImagenTapa"];

                    aux.Estilo = new Estilo();
                    aux.Estilo.Id = (int)datos.lector["idEstilo"];
                    aux.Estilo.Descripcion = (string)datos.lector["Estilo"];

                    aux.Edicion = new Edicion();
                    aux.Edicion.Id = (int)datos.lector["idEdicion"];
                    aux.Edicion.Descripcion = (string)datos.lector["Edición"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Disco agregar)
        {
            datos.setearConsulta("Insert into DISCOS values (@Titulo, @FechaLanzamiento, @CantidadCanciones, @urlImagen, @idEstilo, @idEdicion)");
            datos.setearParametros("Titulo", agregar.Titulo);
            datos.setearParametros("FechaLanzamiento", agregar.FechaLanzamiento);
            datos.setearParametros("CantidadCanciones", agregar.CantidadCanciones);
            datos.setearParametros("urlImagen", agregar.UrlImagenTapa);
            datos.setearParametros("idEstilo", agregar.Estilo.Id);
            datos.setearParametros("idEdicion", agregar.Edicion.Id);

            datos.ejecutarAccion();
        }

        public void modificar(Disco modificar)
        {
            datos.setearConsulta("Update DISCOS set Titulo = @Titulo, FechaLanzamiento = @FechaLanzamiento, CantidadCanciones = @CantidadCanciones, UrlImagenTapa = @UrlImagenTapa, IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion Where id = @Id");
            datos.setearParametros("Id", modificar.Id);
            datos.setearParametros("Titulo",modificar.Titulo);
            datos.setearParametros("FechaLanzamiento", modificar.FechaLanzamiento);
            datos.setearParametros("CantidadCanciones", modificar.CantidadCanciones);
            datos.setearParametros("UrlImagenTapa", modificar.UrlImagenTapa);
            datos.setearParametros("IdEstilo", modificar.Estilo.Id);
            datos.setearParametros("IdTipoEdicion", modificar.Edicion.Id);
            datos.ejecutarAccion();

        }

        public void Eliminar(int id)
        {
            datos.setearConsulta("Delete from DISCOS where id=@disco");
            datos.setearParametros("disco",id);
            datos.ejecutarAccion();
        }
    }



}
