using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ProductoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Producto> _listaProductos;

        public ObservableCollection<Producto> ListaProductos
        {
            get { return _listaProductos; }
            set
            {
                _listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos));
            }
        }

        public ProductoViewModel()
        {
            Util.OnListaProductosChanged += OnListaProductosChanged;
            RefreshListaProductos();
        }

        public ICommand CrearProducto =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProductoPage());
            });

        public async void VerDetalleProducto(Producto producto)
        {
            if(producto != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetalleProductoPage(producto));
            }
        }

        private void OnListaProductosChanged(object sender, EventArgs e)
        {
            // Actualiza la propiedad ListaProductos en el hilo principal
            Device.BeginInvokeOnMainThread(() =>
            {
                RefreshListaProductos();
            });
        }

        private void RefreshListaProductos()
        {
            Util.ListaProductos = App.productoRepository.GetAll();
            ListaProductos = new ObservableCollection<Producto>(Util.ListaProductos);
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
