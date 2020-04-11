using Common.Data.Service;
using FormUI.Componentes;
using FormUI.Formularios.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Modelo = Common.Core.Model;

namespace FormUI.Formularios.Usuario
{
    class UsuarioListadoViewModel : CommonViewModel
    {
        public string Usuario { get; set; }
        public KeyValuePair<bool?, string> HabilitadoSeleccionado { get; set; }
        public List<KeyValuePair<bool?, string>> Habilitado { get; set; } = new List<KeyValuePair<bool?, string>>();
        public SortableBindingList<Modelo.Usuario> Usuarios { get; set; }

        public UsuarioListadoViewModel()
        {
            Habilitado.Add(new KeyValuePair<bool?, string>(null, "Todos"));
            Habilitado.Add(new KeyValuePair<bool?, string>(true, "Si"));
            Habilitado.Add(new KeyValuePair<bool?, string>(false, "No"));
        }

        internal async Task BuscarAsync()
        {
            Usuarios = new SortableBindingList<Modelo.Usuario>(await UsuarioService.Buscar(Usuario, HabilitadoSeleccionado.Key));
            NotifyPropertyChanged(nameof(Usuarios));
        }

        internal async Task NuevoAsync()
        {
            UsuarioDetalleForm usuarioDetalleForm = new UsuarioDetalleForm();
            usuarioDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task BorrarAsync(Modelo.Usuario usuario)
        {
            await UsuarioService.Borrar(usuario);
        }

        internal async Task ModificarAsync(Modelo.Usuario usuario)
        {
            UsuarioDetalleForm usuarioDetalleForm = new UsuarioDetalleForm(usuario);
            usuarioDetalleForm.ShowDialog();
            await BuscarAsync();
        }
    }
}
