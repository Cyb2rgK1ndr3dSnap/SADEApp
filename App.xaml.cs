using AutomatizacionServicios.Handlers;
using AutomatizacionServicios.Models.Startup;
using Microsoft.Maui.Platform;

namespace AutomatizacionServicios;

public partial class App : Application
{

    public static LoginResponse UserInfoDetails;

    public App()
    {
        InitializeComponent();
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
                handler.PlatformView.SetTextColor(Colors.Black.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        MainPage = new AppShell();
    }
}
