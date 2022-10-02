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
		//
		((ListView)sender).SelectedItem = null;
        //((ListView)sender).IsEnabled = false;
    }
}