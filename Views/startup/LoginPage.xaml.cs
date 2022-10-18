using AutomatizacionServicios.ViewModels.Startup;

namespace AutomatizacionServicios.Views.startup;

public partial class LoginPage : ContentPage
{

    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

}