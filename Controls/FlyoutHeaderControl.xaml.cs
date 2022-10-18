namespace AutomatizacionServicios.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
    public FlyoutHeaderControl()
    {
        InitializeComponent();
        Nombre.Text = App.UserInfoDetails.Nombre;
        Correo.Text = App.UserInfoDetails.Correo;
    }
}