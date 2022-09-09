using AutomatizacionServicios.Handlers;
using AutomatizacionServicios.Models;
using Microsoft.Maui.Platform;

namespace AutomatizacionServicios;

public partial class App : Application
{

	public static LoginRequest UserBasicInfo;

	public App()
	{
		InitializeComponent();
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });
        
        MainPage = new AppShell();
    }
}
