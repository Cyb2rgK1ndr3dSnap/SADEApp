using AutomatizacionServicios.Models;
using AutomatizacionServicios.ViewModels;
using AutomatizacionServicios.ViewModels.Startup;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Dispositivos;
using AutomatizacionServicios.Views.Inicio;
using AutomatizacionServicios.Views.startup;
using Newtonsoft.Json;

namespace AutomatizacionServicios;

public partial class AppShell : Shell
{
    public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new AppShellViewModel();

        Routing.RegisterRoute(nameof(CopiasSeleccionPage), typeof(CopiasSeleccionPage));
        Routing.RegisterRoute(nameof(CopiasConfirmarSeleccionPage), typeof(CopiasConfirmarSeleccionPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
    }
}
