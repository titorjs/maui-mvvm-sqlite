using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class ProductoPage : ContentPage
{
    public ProductoPage()
    {
        InitializeComponent();
        BindingContext = new ProductoViewModel();
    }

    void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
        ((ProductoViewModel)BindingContext).VerDetalleProducto(args.SelectedItem as Producto);
    }
}