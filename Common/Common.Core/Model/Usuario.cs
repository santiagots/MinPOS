using Common.Core.Exception;
using Common.Core.Helper;
using System;

namespace Common.Core.Model
{
    public class Usuario : Entity<int>
    {
        public string Alias { get; protected set; }
        public string Nombre { get; protected set; }
        public string Apellido { get; protected set; }
        public string Clave { get; protected set; }
        public bool Habilitado { get; protected set; }
        public DateTime? FechaUltimoAcceso { get; set; }
        public DateTime FechaActualizacion { get; protected set; }
        public string UsuarioActualizacion { get; protected set; }

        internal Usuario() { }

        public Usuario(int id, string alias, string nombre, string apellido, string clave, bool habilitado, DateTime? fechaUltimoAcceso, DateTime fechaActualizacion, string usuarioActualizacion)
        {
            Id = id;
            Alias = alias;
            Nombre = nombre;
            Apellido = apellido;
            Clave = clave;
            Habilitado = habilitado;
            FechaUltimoAcceso = fechaUltimoAcceso;
            FechaActualizacion = fechaActualizacion;
            UsuarioActualizacion = usuarioActualizacion;
        }

        public bool EsLogInCorrecto(string clave)
        {
            if (!Habilitado)
                throw new NegocioException("El usuario ingresado se encuentra deshabilitado.");

            if (Clave != Encriptado.Encriptar(clave))
                throw new NegocioException("La contraseña ingresada es incorrecta.");

            FechaUltimoAcceso = DateTime.Now;
            return true;
        }
    }
}
