
using AutomatizacionServicios.ViewModels;

namespace AutomatizacionServicios.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
        Nombre.Text = App.UserInfoDetails.nombre;
        Correo.Text = App.UserInfoDetails.correo;
        /*AppShellViewModel shellViewModel = new AppShellViewModel();
        string tipo = App.UserInfoDetails.tipo_usuario_id;
        if (tipo=="3")
        {
            shellViewModel.Parametro = false;
        }
        else
        {
            shellViewModel.Parametro = true;
        }*/
        //shellViewModel.Parameters=false;
        /*if (Preferences.ContainsKey(nameof(App.UserInfoDetails)))*/
    }
}