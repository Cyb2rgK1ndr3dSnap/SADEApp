using AutomatizacionServicios.Models;
using AutomatizacionServicios.ViewModels;
using AutomatizacionServicios.ViewModels.Startup;
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
        //this.BindingContext = viewModel;
        this.BindingContext = new AppShellViewModel();


        //Routing.RegisterRoute(nameof(DispositivosPage), typeof(DispositivosPage));
        //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        /*Routing.RegisterRoute(nameof(LoginPageViewModel), typeof(LoginPageViewModel));*/
        //Routing.RegisterRoute(nameof(InicioPage), typeof(InicioPage));
        /*string userInfoDetailsStr = Preferences.Get(nameof(App.UserInfoDetails), "");
        var userInfoDetails = JsonConvert.DeserializeObject<LoginResponse>(userInfoDetailsStr);
        App.UserInfoDetails = userInfoDetails;
        App.PruebaShell = myItem;
        /*if (Preferences.ContainsKey(nameof(App.UserInfoDetails)))
        {
            var tipo = App.UserInfoDetails.tipo_usuario_id;
            if (tipo == "3")
            {
                myItem.IsVisible = false;
            }
        }*/
    }
}
