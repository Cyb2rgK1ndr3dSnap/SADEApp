using CommunityToolkit.Mvvm.ComponentModel;

namespace AutomatizacionServicios.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        private bool _isBusy;


        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private bool _lstState;

        [ObservableProperty]
        private bool _isRefreshing;
    }
}
