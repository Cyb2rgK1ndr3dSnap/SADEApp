using AutomatizacionServicios.ViewModels.Inicio;

namespace AutomatizacionServicios.Views.Inicio
{

    public partial class InicioPage : ContentPage
    {
        public InicioPage(InicioPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new InicioPageViewModel();

        }
    }
}