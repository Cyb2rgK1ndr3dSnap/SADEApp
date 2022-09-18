using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Inicio;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Copias
{
    public partial class CopiasPageViewModel : BaseViewModel
    {
        #region Commands
        [RelayCommand]
        async void Seleccion()
        {
            await Shell.Current.GoToAsync($"{nameof(CopiasSeleccionPage)}",false);
        }
        #endregion
    }
}
