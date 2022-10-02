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

        [ObservableProperty]
        private bool _lstState;

        [ObservableProperty]
        private bool _isRefreshing;

        //[ObservableProperty]

        //[ObservableProperty] _isRefreshing

        /*
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        */
    }
}
