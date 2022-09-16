using AutomatizacionServicios.ViewModels;
using AutomatizacionServicios.ViewModels.Dispositivos;
using AutomatizacionServicios.ViewModels.Inicio;
using AutomatizacionServicios.ViewModels.Startup;
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
        //View
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddSingleton<InicioPage>();
        //builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddTransient<DispositivosPage>();
        //ViewModels
        builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddSingleton<InicioPageViewModel>();
        builder.Services.AddSingleton<AppShellViewModel>();
        builder.Services.AddTransient<DispositivosPageViewModel>();

        return builder.Build();
    }
}
