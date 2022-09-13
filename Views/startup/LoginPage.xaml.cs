using AutomatizacionServicios.ViewModels.Startup;
using System.Net;

namespace AutomatizacionServicios.Views.startup;

public partial class LoginPage : ContentPage
{

    public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
    
}