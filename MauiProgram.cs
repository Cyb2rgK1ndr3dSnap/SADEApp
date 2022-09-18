using AutomatizacionServicios.ViewModels;
using AutomatizacionServicios.ViewModels.Copias;
using AutomatizacionServicios.ViewModels.Dispositivos;
using AutomatizacionServicios.ViewModels.Inicio;
using AutomatizacionServicios.ViewModels.Startup;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Dispositivos;
using AutomatizacionServicios.Views.Inicio;
using AutomatizacionServicios.Views.startup;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatizacionServicios;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //return builder.Build();
        //builder.Services.AddSingleton<>();
        //View
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddSingleton<InicioPage>();
        builder.Services.AddTransient<DispositivosPage>();
        builder.Services.AddTransient<CopiasPage>();
        builder.Services.AddTransient<CopiasSeleccionPage>();

        //ViewModels
        builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddSingleton<InicioPageViewModel>();
        builder.Services.AddTransient<DispositivosPageViewModel>();
        builder.Services.AddTransient<CopiasPageViewModel>();
        builder.Services.AddTransient<CopiasSeleccionPageViewModel>();

        return builder.Build();
    }
}
