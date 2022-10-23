using AutomatizacionServicios.ViewModels.Copias;
using System.ComponentModel;

namespace AutomatizacionServicios.Views.Copias;
[DesignTimeVisible(false)]
public partial class CopiasConfirmarPage : ContentPage
{
    public CopiasConfirmarPage(/*CopiasConfirmarViewModel viewModel*/)
    {
        InitializeComponent();
        //this.BindingContext = viewModel;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.BindingContext = new CopiasConfirmarViewModel();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        this.BindingContext = null;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        this.BindingContext = new CopiasConfirmarViewModel();
        base.OnNavigatedTo(args);
    }

    protected override void OnParentChanged()
    {
        base.OnParentChanged();
        this.BindingContext = new CopiasConfirmarViewModel();
    }

    protected override void OnParentChanging(ParentChangingEventArgs args)
    {
        base.OnParentChanging(args);
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }
}