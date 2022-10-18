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
        builder.Services.AddSingleton<AppShell>();

        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();

        builder.Services.AddTransient<InicioPage>();

        builder.Services.AddSingleton<MaterialesPage>();
        builder.Services.AddTransient<MaterialesAgregarPage>();

        builder.Services.AddSingleton<CopiasPage>();
        builder.Services.AddTransient<CopiasSeleccionPage>();
        builder.Services.AddSingleton<CopiasConfirmarPage>();
        builder.Services.AddTransient<CopiasConfirmarSeleccionPage>();

        builder.Services.AddTransient<DispositivosPage>();

        //ViewModels Login
        builder.Services.AddSingleton<AppShellViewModel>();
        builder.Services.AddTransient<RegisterPageViewModel>();
        builder.Services.AddTransient<LoadingPageViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();

        builder.Services.AddTransient<InicioPageViewModel>();

        builder.Services.AddSingleton<MaterialesPageViewModel>();
        builder.Services.AddTransient<MaterialesAgregarPageViewModel>();

        builder.Services.AddSingleton<CopiasPageViewModel>();
        builder.Services.AddTransient<CopiasSeleccionPageViewModel>();
        builder.Services.AddSingleton<CopiasConfirmarViewModel>();
        builder.Services.AddTransient<CopiasConfirmarSeleccionViewModel>();

        builder.Services.AddTransient<DispositivosPageViewModel>();
        return builder.Build();
    }
}
