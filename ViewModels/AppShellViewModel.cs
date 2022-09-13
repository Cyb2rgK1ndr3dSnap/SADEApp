using AutomatizacionServicios.Views.startup;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [RelayCommand]
        async void CerrarSesion()
        {
            if (Preferences.ContainsKey(nameof(App.UserInfoDetails)))
            {
                Preferences.Remove(nameof(App.UserInfoDetails));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
