using AutomatizacionServicios.Models;
using AutomatizacionServicios.Models.Startup;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.Views.Inicio;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Net;

namespace AutomatizacionServicios.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        readonly ILoginRepository iLoginRepository = new LoginService();
        //readonly IGetPost getPost = new LServices();
        readonly LServices getPost = new LServices();

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        #region Commands

        [RelayCommand]
        async void LoginP()
        {
            await Shell.Current.GoToAsync($"//{nameof(InicioPage)}");
        }
        /// <summary>
        /// ARREGLAR EL LOGIN CUANDO SE PRESIONE SE DESHABILITE EL BOTÓN HASTA QUE CONFIRME Y ENTRE O DE ERROR
        /// </summary>
        [RelayCommand]
         void Login()
        {
            Task.Run(async () =>
            {
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                        {
                            //LoginResponse loginResponse = await iLoginRepository.Login(Email, Password);
                            LoginResponse loginResponse = await getPost.LoginSer(Email, Password);
                            //App.UserInfo = await iLoginRepository.Login(Email, Password);

                            if (loginResponse != null)
                            {
                                Email = "";
                                Password = "";
                                if (Preferences.ContainsKey(nameof(App.UserInfoDetails)))
                                {
                                    Preferences.Remove(nameof(App.UserInfoDetails));
                                    //Preferences.Clear();
                                }
                                string userInfoDetails = JsonConvert.SerializeObject(loginResponse);
                                Preferences.Set(nameof(App.UserInfoDetails), userInfoDetails);
                                App.UserInfoDetails = loginResponse;
                                //await AppConstant.AddFlyoutMenusDetails();
                                AppConstant.AddFlyoutMenusDetails();
                            }
                            else
                            {
                                Password = "";                                
                                await Application.Current.MainPage.DisplayAlert("Warning", "usuario o contraseña incorrectos", "OK");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Incorrecto", "Ingresa el usuario y contraseña", "OK");
                        }
                    }
                    catch (HttpRequestException)
                    {
                        Password = "";
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Sin conexión a internet", "OK");
                    }
                    catch (WebException)
                    {
                        Password = "";
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Problemas al cargar el feed", "OK");
                    }
                });
            });
        }



        [RelayCommand]
        async Task RegisterPage()
        {
                await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
        #endregion
    }
}
