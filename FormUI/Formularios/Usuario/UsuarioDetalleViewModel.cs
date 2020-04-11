using Common.Core.Exception;
using Common.Core.Helper;
using Common.Core.Model;
using Common.Data.Service;
using FormUI.Componentes;
using System;
using System.Threading.Tasks;
using Modelo = Common.Core.Model;

namespace FormUI.Formularios.Usuario
{
    public class UsuarioDetalleViewModel
    {
        private int Id = 0;

        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string RepetirClave { get; set; }
        public bool Habilitado { get; set; } = true;
        public DateTime? FechaUltimoAcceso { get; set; }
        public DateTime? FechaUltimoActualizacion { get; set; }
        public string UsuarioActualizacion { get; set; }

        public UsuarioDetalleViewModel()
        {
            UsuarioActualizacion = Sesion.Usuario.Alias;
        }

        public UsuarioDetalleViewModel(Modelo.Usuario usuario)
        {
            Id = usuario.Id;
            Usuario = usuario.Alias;
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Clave = Encriptado.Desencriptar(usuario.Clave);
            RepetirClave = Encriptado.Desencriptar(usuario.Clave);
            Habilitado = usuario.Habilitado;
            FechaUltimoAcceso = usuario.FechaUltimoAcceso;
            FechaUltimoActualizacion = usuario.FechaActualizacion;
            UsuarioActualizacion = usuario.UsuarioActualizacion;
        }

        internal async Task GuardarAsync()
        {
            if (Clave != RepetirClave)
                throw new NegocioException("La contraseña y su repetición no coinciden. Por favor, ingrese el mismo valor en ambos campos.");

            Modelo.Usuario usuario = new Modelo.Usuario(Id, Usuario, Nombre, Apellido, Clave, Habilitado, FechaUltimoAcceso, DateTime.Now, Sesion.Usuario.Alias);
            await UsuarioService.Guardar(usuario);
        }
    }
}
