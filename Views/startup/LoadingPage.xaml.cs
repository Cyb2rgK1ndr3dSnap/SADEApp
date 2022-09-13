using AutomatizacionServicios.ViewModels.Startup;

namespace AutomatizacionServicios.Views.startup;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext=viewModel;
	}
}