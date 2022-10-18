using AutomatizacionServicios.Views.startup;
using CommunityToolkit.Mvvm.Input;

namespace AutomatizacionServicios.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        #region Commands
        [RelayCommand]
        async void CerrarSesion()
        {
            if (Preferences.ContainsKey(nameof(App.UserInfoDetails)))
            {
                Preferences.Remove(nameof(App.UserInfoDetails));
                //Preferences.Clear();
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        #endregion
    }
}
