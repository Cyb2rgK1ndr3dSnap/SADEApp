using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutomatizacionServicios.ViewModels.Startup
{
    public partial class RegisterPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string txtNombre;

        [ObservableProperty]
        private string txtApellido;

        [ObservableProperty]
        private string txtCorreo;

        [ObservableProperty]
        private string txtContrasena;

        [ObservableProperty]
        private string txtConstrasenaConfirm;

        [ObservableProperty]
        private bool flag;

        [RelayCommand]
        async Task Registrarse()
        {
            bool flag = false;

            flag = string.IsNullOrEmpty(TxtNombre) && string.IsNullOrEmpty(TxtApellido) && string.IsNullOrEmpty(TxtCorreo) && string.IsNullOrEmpty(TxtContrasena) && string.IsNullOrEmpty(TxtConstrasenaConfirm) ? false : true;

            if (flag == true)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Por favor ingresar todos los campos", "OK");
            }
        }
    }
}
