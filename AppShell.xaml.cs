using AutomatizacionServicios.ViewModels;
using AutomatizacionServicios.ViewModels.Startup;
using AutomatizacionServicios.Views.Dispositivos;
using AutomatizacionServicios.Views.Inicio;
using AutomatizacionServicios.Views.startup;

namespace AutomatizacionServicios;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();

        /*Routing.RegisterRoute(nameof(DispositivosPage), typeof(DispositivosPage));
        /*Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(LoginPageViewModel), typeof(LoginPageViewModel));*/
        //Routing.RegisterRoute(nameof(InicioPage), typeof(InicioPage));
    }

	private void ShellContent_ChildRemoved(object sender, ElementEventArgs e)
	{

	}
}
