using AutomatizacionServicios.Models;
using AutomatizacionServicios.Models.Startup;
using AutomatizacionServicios.Views.startup;
using Newtonsoft.Json;

namespace AutomatizacionServicios.ViewModels.Startup
{
    public class LoadingPageViewModel
    {

        public LoadingPageViewModel()
        {
            CheckUserIsConnect();
        }

        void CheckUserIsConnect()
        {
            Task.Run(async () =>
            {
            await Task.Delay(1000);
            string userInfoDetailsStr = Preferences.Get(nameof(App.UserInfoDetails), "");

                if (string.IsNullOrWhiteSpace(userInfoDetailsStr))
                {

                    if (DeviceInfo.Platform == DevicePlatform.WinUI)
                    {
                        AppShell.Current.Dispatcher.Dispatch(async () =>
                        {
                            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                        });
                    }
                    else
                    {
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    }
                }
                else
                {
                        var userInfoDetails = JsonConvert.DeserializeObject<LoginResponse>(userInfoDetailsStr);
                        App.UserInfoDetails = userInfoDetails;
                        //await AppConstant.AddFlyoutMenusDetails();
                        AppConstant.AddFlyoutMenusDetails();
                }
            });
        }
    }

}

