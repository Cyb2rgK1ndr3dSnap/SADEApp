using AutomatizacionServicios.ViewModels.Materiales;

namespace AutomatizacionServicios.Views.Materiales;

public partial class MaterialesSeleccionPage : ContentPage
{
	public MaterialesSeleccionPage(MaterialesSeleccionPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}