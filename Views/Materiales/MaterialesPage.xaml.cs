using AutomatizacionServicios.ViewModels.Materiales;

namespace AutomatizacionServicios.Views.Materiales;

public partial class MaterialesPage : ContentPage
{
	public MaterialesPage(/*MaterialesPageViewModel vm*/)
	{
		InitializeComponent();
		//this.BindingContext = vm;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		this.BindingContext = new MaterialesPageViewModel();
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
        this.BindingContext = null;

    }

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{

	}
}