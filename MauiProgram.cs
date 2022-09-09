using AutomatizacionServicios.ViewModels.Startup;
using AutomatizacionServicios.Views.Inicio;
using AutomatizacionServicios.Views.startup;

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
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<InicioPage>();
        builder.Services.AddSingleton<RegisterPage>();
        //ViewModels
        builder.Services.AddSingleton<LoginPageViewModel>();

        return builder.Build();
    }
}
