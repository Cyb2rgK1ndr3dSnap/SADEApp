using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Materiales
{
    [QueryProperty(nameof(MatId), nameof(MatId))]
    [QueryProperty(nameof(MatFacultadId), nameof(MatFacultadId))]
    [QueryProperty(nameof(MatSelect), nameof(MatSelect))]
    [QueryProperty(nameof(MatColor), nameof(MatColor))]
    public partial class MaterialesSeleccionPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string matId;

        [ObservableProperty]
        public string matFacultadId;

        [ObservableProperty]
        public string matSelect;

        [ObservableProperty]
        public string matColor;

        public MaterialesSeleccionPageViewModel()
        {

        }

    }
}
