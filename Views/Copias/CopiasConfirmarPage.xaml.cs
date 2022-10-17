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
	
	
}