using AutomatizacionServicios.ViewModels.Startup;

namespace AutomatizacionServicios.Views.startup;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}