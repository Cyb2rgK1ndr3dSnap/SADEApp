using AutomatizacionServicios.ViewModels.Materiales;

namespace AutomatizacionServicios.Views.Materiales;

public partial class MaterialesPage : ContentPage
{
	public MaterialesPage(MaterialesPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;

	}

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{

	}
}