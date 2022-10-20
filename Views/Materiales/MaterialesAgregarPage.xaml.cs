using AutomatizacionServicios.ViewModels.Materiales;

namespace AutomatizacionServicios.Views.Materiales;

public partial class MaterialesAgregarPage : ContentPage
{
    public MaterialesAgregarPage(MaterialesAgregarPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext=vm;
    }
}