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
        //Routing.RegisterRoute(nameof(CopiasConfirmarPage), typeof(CopiasConfirmarPage));

    }
    // ...
    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        //########## COLOR TOKEN DE VERIFICACIÓN AQUÍ SI EL TIPO INICIO EN OTRO CELULAR QUE SE LO CIERRE
        base.OnNavigating(args);
        //await Shell.Current.GoToAsync("..");
        /*ShellNavigatingDeferral token = args.GetDeferral();

        var result = await DisplayActionSheet("Navigate?", "Cancel", "Yes", "No");
        if (result != "Yes")
        {
            args.Cancel();
        }
        token.Complete();*/
    }

    bool startUp = true;
    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);
        startUp = false;
    }

    protected async override void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (!startUp && propertyName.Equals("CurrentItem") && DeviceInfo.Platform == DevicePlatform.Android)
        {
            FlyoutIsPresented = true;
            await System.Threading.Tasks.Task.Delay(300);
            FlyoutIsPresented = false;
        }
    }
}
