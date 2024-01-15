using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    public class DetalleProductoViewModel
    {
        private Producto _producto;
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }

        public DetalleProductoViewModel(Producto producto)
        {
            _producto = producto;
            Nombre = _producto.Nombre;
            Cantidad = _producto.Cantidad.ToString();
            Descripcion = _producto.Descripcion;
        }

        public ICommand GuardarProducto =>
            new Command(async () =>
            {
                _producto.Nombre = Nombre;
                _producto.Cantidad = Int32.Parse(Cantidad);
                _producto.Descripcion = Descripcion;
                App.productoRepository.Update(_producto);
                Util.ListaProductos = App.productoRepository.GetAll();
                await App.Current.MainPage.Navigation.PopAsync();
            });

        public ICommand EliminarProducto =>
            new Command(async () =>
            {
                App.productoRepository.Delete(_producto);
                Util.ListaProductos = App.productoRepository.GetAll();
                await App.Current.MainPage.Navigation.PopAsync();
            });
    }
}
