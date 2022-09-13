using AutomatizacionServicios.ViewModels.Dispositivos;
using Microsoft.Maui.Controls;

namespace AutomatizacionServicios.Views.Dispositivos;

public partial class DispositivosPage : ContentPage
{
	public DispositivosPage(DispositivosPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

}