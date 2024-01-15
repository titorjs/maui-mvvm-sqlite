using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class DetalleProductoPage : ContentPage
{
	public DetalleProductoPage(Producto producto)
	{
		InitializeComponent();
		BindingContext = new DetalleProductoViewModel(producto);
	}
}