using AutomatizacionServicios.ViewModels;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Materiales;
using AutomatizacionServicios.Views.startup;

namespace AutomatizacionServicios;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        this.BindingContext = new AppShellViewModel();

        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(CopiasSeleccionPage), typeof(CopiasSeleccionPage));
        Routing.RegisterRoute(nameof(CopiasConfirmarSeleccionPage), typeof(CopiasConfirmarSeleccionPage));
        Routing.RegisterRoute(nameof(MaterialesAgregarPage), typeof(MaterialesAgregarPage));
    }
}
