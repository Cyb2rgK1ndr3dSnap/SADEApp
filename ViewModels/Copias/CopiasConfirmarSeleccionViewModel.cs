using CommunityToolkit.Mvvm.ComponentModel;

namespace AutomatizacionServicios.ViewModels.Copias
{
    [QueryProperty(nameof(IdSelect), nameof(IdSelect))]
    public partial class CopiasConfirmarSeleccionViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string idSelect;

        [ObservableProperty]
        public string texto;

        public CopiasConfirmarSeleccionViewModel()
        {
            Texto = IdSelect;
        }
    }
}
