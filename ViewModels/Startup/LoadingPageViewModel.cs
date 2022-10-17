using AutomatizacionServicios.Controls;
using AutomatizacionServicios.Models;
using AutomatizacionServicios.Models.Startup;
using AutomatizacionServicios.Views.Inicio;
using AutomatizacionServicios.Views.startup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Startup
{
    public class LoadingPageViewModel 
    {

        public LoadingPageViewModel()
        {
            CheckUserIsConnect();
        }

        private async void CheckUserIsConnect()
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
                // navigate to Login Page
            }
            else
            {
                var userInfoDetails = JsonConvert.DeserializeObject<LoginResponse>(userInfoDetailsStr);
                App.UserInfoDetails = userInfoDetails;
                //AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                await AppConstant.AddFlyoutMenusDetails();
                //await Shell.Current.GoToAsync($"//{nameof(InicioPage)}"); 
            }
        }
    }

}   

