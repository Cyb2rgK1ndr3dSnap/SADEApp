using AutomatizacionServicios.ViewModels.Copias;

namespace AutomatizacionServicios.Views.Copias;

public partial class CopiasSeleccionPage : ContentPage
{
	public CopiasSeleccionPage(CopiasSeleccionPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}