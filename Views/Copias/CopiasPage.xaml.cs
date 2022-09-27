using AutomatizacionServicios.Models;
using AutomatizacionServicios.ViewModels.Copias;
using Newtonsoft.Json;

namespace AutomatizacionServicios.Views.Copias;

public partial class CopiasPage : ContentPage
{
	public CopiasPage(CopiasPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;
	}

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		CopiaseImpresionesResponse copias = e.Item as CopiaseImpresionesResponse;
		
        Shell.Current.GoToAsync($"{nameof(CopiasSeleccionPage)}", 
			new Dictionary<string,object> 
			{	["SerId"] = copias.Id,
				["SerSelect"] = copias.Nombre,
				["SerCorta"] = copias.Corta,
				["SerLarga"] = copias.Larga,
				["SerColor"] = copias.Color
            });
        /*string objeto = JsonConvert.SerializeObject(copias);
		 * ?SerId={copias.Id}?SerSelect={copias.Nombre}?SerCorta={copias.Corta}?SerLarga={copias.Larga}?SerColor={copias.Color}
        Shell.Current.GoToAsync($"{nameof(CopiasSeleccionPage)}?Objeto={objeto}");*/

    }
}