﻿using FormUI.Formularios.Common;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Producto
{
    public partial class ProductoIngresoMasivo : CommonForm
    {
        private bool editandoProducto = false;

        ProductoIngresoMasivoViewModel productoIngresoMasivoViewModel = new ProductoIngresoMasivoViewModel();
        public ProductoIngresoMasivo()
        {
            InitializeComponent();
        }

        private void ProductoIngresoMasivo_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                productoIngresoMasivoViewModelBindingSource.DataSource = productoIngresoMasivoViewModel;
                this.WindowState = FormWindowState.Maximized;
                await productoIngresoMasivoViewModel.CargarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                editandoProducto = false;
                await productoIngresoMasivoViewModel.GuardarAsync();
                cmbCategoria.SelectedIndex = 0;
                cmbProveedor.SelectedIndex = 0;
            });
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ProveedorDetalleForm proveedorDetalle = new ProveedorDetalleForm();
                proveedorDetalle.ShowDialog();
                await productoIngresoMasivoViewModel.CargarAsync();
            });
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                CategoriaDetalleForm categoriaDetalleForm = new CategoriaDetalleForm();
                categoriaDetalleForm.ShowDialog();
                await productoIngresoMasivoViewModel.CargarAsync();
            });
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                editandoProducto = false;
                productoIngresoMasivoViewModel.Limpiar();
                cmbCategoria.SelectedIndex = 0;
                cmbProveedor.SelectedIndex = 0;
            });
        }

        private void dgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Ejecutar(() =>
            {
                if (e.RowIndex < 0) return;

                editandoProducto = true;
                dgProductos.Rows[e.RowIndex].Selected = true;
                ProductoIngresoMasivoItem productoIngresoMasivoItem = (ProductoIngresoMasivoItem)dgProductos.Rows[e.RowIndex].DataBoundItem;
                productoIngresoMasivoViewModel.CargarProducto(productoIngresoMasivoItem.ProductoItem);
            });
        }

        private void dgProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (!editandoProducto)
                dgProductos.ClearSelection();
        }
    }
}
