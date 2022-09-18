using AutomatizacionServicios.ViewModels.Copias;

namespace AutomatizacionServicios.Views.Copias;

public partial class CopiasPage : ContentPage
{
	public CopiasPage(CopiasPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;
	}
}