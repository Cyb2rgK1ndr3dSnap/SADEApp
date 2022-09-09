using static System.Net.Mime.MediaTypeNames;

namespace AutomatizacionServicios.Views.Inicio;

public partial class InicioPage : ContentPage
{

    public InicioPage()
	{
		InitializeComponent();
		ObtenerDatos();
    }

	private void ObtenerDatos()
	{
        lblId.Text = Preferences.Get("nombre",null);
        lblNombre.Text = Preferences.Get("apellido",null);
        //Apellido.Text = await SecureStorage.Default.GetAsync("apellido");
    }

}