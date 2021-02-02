using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios.Entidades
{
    public class Persona
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
        public string Rol { get; set; }
        public int RolId { get; set; }
        public bool Activo { get; set; }
        public DateTime  FechaIngreso { get; set; }

        public Persona()
        {
            UsuarioId = 0;
            Alias = string.Empty;
            Nombre = string.Empty;
            Email = string.Empty;
            Clave = string.Empty;
            ConfirmarClave = string.Empty;
            Rol = string.Empty;
            RolId = 0;
            Activo = false;
            FechaIngreso = DateTime.Now;
        }
    }
}
