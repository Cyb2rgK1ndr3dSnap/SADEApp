using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
