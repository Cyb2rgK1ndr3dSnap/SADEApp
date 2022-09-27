using AutomatizacionServicios.Models;
using AutomatizacionServicios.ViewModels.Copias;

namespace AutomatizacionServicios.Views.Copias;

public partial class CopiasConfirmarPage : ContentPage
{
	public CopiasConfirmarPage(CopiasConfirmarViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		Usuarios usuarios = e.Item as Usuarios;
        Shell.Current.GoToAsync($"{nameof(CopiasConfirmarSeleccionPage)}?IdSelect={usuarios.Cedula}");
    }
}