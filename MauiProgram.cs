using AutomatizacionServicios.ViewModels;
using AutomatizacionServicios.ViewModels.Copias;
using AutomatizacionServicios.ViewModels.Dispositivos;
using AutomatizacionServicios.ViewModels.Inicio;
using AutomatizacionServicios.ViewModels.Materiales;
using AutomatizacionServicios.ViewModels.Startup;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Dispositivos;
using AutomatizacionServicios.Views.Inicio;
using AutomatizacionServicios.Views.Materiales;
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
        /////////////////////////////////////ORDENAR DE UNA MEJOR MANERA ESTA SECCIÓN DEL CÓDIGO PARA MÁS LEGIBILIDAD
        //return builder.Build();
        //builder.Services.AddSingleton<>();

        //View
        //builder.Services.AddTransient<AppShell>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();

        builder.Services.AddSingleton<InicioPage>();

        builder.Services.AddTransient<MaterialesPage>();

        builder.Services.AddTransient<CopiasPage>();
        builder.Services.AddTransient<CopiasSeleccionPage>();
        builder.Services.AddTransient<CopiasConfirmarPage>();
        builder.Services.AddTransient<CopiasConfirmarSeleccionPage>();

        builder.Services.AddTransient<DispositivosPage>();

        //ViewModels Login
        //builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<RegisterPageViewModel>();
        builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();

        builder.Services.AddSingleton<InicioPageViewModel>();

        builder.Services.AddTransient<MaterialesPageViewModel>();

        builder.Services.AddTransient<CopiasPageViewModel>();
        builder.Services.AddTransient<CopiasSeleccionPageViewModel>();
        builder.Services.AddTransient<CopiasConfirmarViewModel>();
        builder.Services.AddTransient<CopiasConfirmarSeleccionViewModel>();

        builder.Services.AddTransient<DispositivosPageViewModel>();
        return builder.Build();
    }
}
