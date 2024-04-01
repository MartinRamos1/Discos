using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //public enum TipoUsuario
    //{
    //    NORMAL = 0,
    //    ADMIN = 1
    //}
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoUsuario { get; set; }
        public string ImagenPerfil { get; set; }
    }

}
