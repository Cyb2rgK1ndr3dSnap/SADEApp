using CommunityToolkit.Mvvm.ComponentModel;

namespace AutomatizacionServicios.ViewModels.Dispositivos
{
    public partial class DispositivosPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _busqueda;

        [ObservableProperty]
        private string _prueba2;



        public DispositivosPageViewModel()
        {

        }

    }
}
