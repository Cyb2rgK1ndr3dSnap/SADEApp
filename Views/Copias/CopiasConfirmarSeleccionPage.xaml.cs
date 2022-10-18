using AutomatizacionServicios.ViewModels.Copias;

namespace AutomatizacionServicios.Views.Copias;

public partial class CopiasConfirmarSeleccionPage : ContentPage
{
    public CopiasConfirmarSeleccionPage(CopiasConfirmarSeleccionViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}