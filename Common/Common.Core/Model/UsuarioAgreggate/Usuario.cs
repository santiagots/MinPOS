
using System;

namespace Common.Core.Model.UsuarioAgreggate
{
    public class Usuario
    {
        public string Alias { get; protected set; }
        public string Nombre { get; protected set; }
        public string Apellido { get; protected set; }
        public string Contrasenia { get; protected set; }
        public DateTime FechaUltimoAcceso { get; set; }
        public DateTime FechaActualizacion { get; protected set; }
        public string UsuarioActualizacion { get; protected set; }

        public Usuario(string alias, string nombre, string apellido, string contrasenia, DateTime fechaUltimoAcceso, DateTime fechaActualizacion, string usuarioActualizacion)
        {
            Alias = alias;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            FechaUltimoAcceso = fechaUltimoAcceso;
            FechaActualizacion = fechaActualizacion;
            UsuarioActualizacion = usuarioActualizacion;
        }
    }
}
