using AutomatizacionServicios.Models;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.ViewModels.Startup;
using System.Net;

namespace AutomatizacionServicios.Views.startup;

public partial class LoginPage : ContentPage
{

    

    public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
    /*
    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        string userName = UserName.Text;
        string password = Password.Text;

        try
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password) && Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {

                    LoginResponse loginResponse = await iLoginRepository.Login(userName, password);

                    if (loginResponse != null)
                    {
                        Preferences.Default.Set("nombre", loginResponse.nombre);
                        Preferences.Default.Set("apellido", loginResponse.apellido);                  
                        await Shell.Current.GoToAsync($"//{nameof(Inicio)}");                    
                }
                    else
                    {
                        await DisplayAlert("Warning", "usuario o contraseña incorrectos", "OK");
                    }
            }
            else
            {
                await DisplayAlert("Incorrecto", "Ingresa el usuario y contraseña", "OK");
                return;
            }
        }
        catch(HttpRequestException)
        {
            await DisplayAlert("Connection Problem 500", "Sin conexión a internet", "OK");
        }
        catch (WebException)
        {
            await DisplayAlert("Connection Problem 500", "Error al conectarse", "OK");
        }
    }*/
}