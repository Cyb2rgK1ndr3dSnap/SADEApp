using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]  
        private bool _isBusy;


        [ObservableProperty]
        private string _title;
        
    }
}
