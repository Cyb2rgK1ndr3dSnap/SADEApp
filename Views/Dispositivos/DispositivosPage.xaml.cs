using AutomatizacionServicios.ViewModels.Dispositivos;

namespace AutomatizacionServicios.Views.Dispositivos;

public partial class DispositivosPage : ContentPage
{
    public DispositivosPage(DispositivosPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

}