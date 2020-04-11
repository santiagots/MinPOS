using Common.Data.Service;
using Common.Core.Helper;
using Modelo = Common.Core.Model;
using System.Threading.Tasks;
using Common.Core.Exception;
using System;
using FormUI.Componentes;

namespace FormUI.Formularios.Usuario
{
    public class LogInViewModel
    {
        public string Alias { get; set; }
        public string Clave { get; set; }

        internal async Task IngresarAsync()
        {
            Modelo.Usuario usuario = await UsuarioService.Obtener(Alias);

            if (usuario == null)
                throw new NegocioException("El usuario ingresado no existe.");

            if (usuario.EsLogInCorrecto(Clave))
            {
                await UsuarioService.Guardar(usuario);
                Sesion.Usuario = usuario;
            }
        }
    }
}
