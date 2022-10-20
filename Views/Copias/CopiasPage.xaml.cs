using AutomatizacionServicios.ViewModels.Copias;

namespace AutomatizacionServicios.Views.Copias;

public partial class CopiasPage : ContentPage
{
    public CopiasPage(/*CopiasPageViewModel viewModel*/)
    {
        InitializeComponent();
        //this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.BindingContext= new CopiasPageViewModel();
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ((ListView)sender).SelectedItem = null;
    }


}