using AutomatizacionServicios.Views.Dispositivos;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Dispositivos
{
    public partial class DispositivosPageViewModel : BaseViewModel 
    {
        [ObservableProperty]
        private string _prueba;

        [ObservableProperty]
        private string _prueba2;

        public DispositivosPageViewModel(){
            Prueba2 = Prueba; 
        }

    }
}
