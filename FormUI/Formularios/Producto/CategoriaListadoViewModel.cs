﻿using Producto.Core.Model;
using Producto.Data.Service;
using System.Threading.Tasks;
using FormUI.Componentes;
using FormUI.Formularios.Common;

namespace FormUI.Formularios.Producto
{
    class CategoriaListadoViewModel: CommonViewModel
    {
        public string Descripcion { get; set; }
        public SortableBindingList<Categoria> Categorias { get; set; }

        internal async Task BuscarAsync()
        {
            Categorias = new SortableBindingList<Categoria>(await CategoriaService.Buscar(Descripcion));
            NotifyPropertyChanged(nameof(Categorias));
        }

        internal async Task BorrarAsync(Categoria categoria)
        {
            await CategoriaService.Borrar(categoria);
            await BuscarAsync();
        }

        internal async Task NuevoAsync()
        {
            CategoriaDetalleForm categoriaDetalleForm = new CategoriaDetalleForm();
            categoriaDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task ModificarAsync(Categoria categoria)
        {
            CategoriaDetalleForm categoriaDetalleForm = new CategoriaDetalleForm(categoria);
            categoriaDetalleForm.ShowDialog();
            await BuscarAsync();
        }
    }
}