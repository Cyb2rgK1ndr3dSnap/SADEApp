using AutomatizacionServicios.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Copias
{
    [QueryProperty(nameof(SerSelect), nameof(SerSelect))]
    [QueryProperty(nameof(SerCorta), nameof(SerCorta))]
    [QueryProperty(nameof(SerLarga), nameof(SerLarga))]
    [QueryProperty(nameof(SerColor), nameof(SerColor))]
    [QueryProperty(nameof(SerId), nameof(SerId))]
    //[QueryProperty(nameof(Objeto), nameof(Objeto))]
    public partial class CopiasSeleccionPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        public string serSelect;

        [ObservableProperty]
        public string serId;

        [ObservableProperty]
        public bool serCorta;

        [ObservableProperty]
        public bool serLarga;

        [ObservableProperty]
        public bool serColor;

        [ObservableProperty]
        private string _user;

        //[ObservableProperty]
        /*private CopiaseImpresionesResponse objeto;
        
        public CopiaseImpresionesResponse Objeto
        {
            get => objeto;
            set
            {
                var copiaseImpresionesResponse = new CopiaseImpresionesResponse();
                //copiaseImpresionesResponse = JsonConvert.DeserializeObject(value);
                copiaseImpresionesResponse = value;
                SetProperty(ref objeto, copiaseImpresionesResponse);
            }
        }*/

        [ObservableProperty]
        private string _identificacion;
        /*
        public string User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }*/
        /*
        public string Identificacion
        {
            get => _identificacion;
            set => SetProperty(ref _identificacion, value);
        }*/

        public CopiasSeleccionPageViewModel()
        {
            User = App.UserInfoDetails.Nombre;
            Identificacion = App.UserInfoDetails.Cedula;
        }

        #region Commands
        /*[RelayCommand]
        async void ScannerId()
        {
            Identificacion = "";
        }*/

        [RelayCommand]
        async void Volver() => await Shell.Current.GoToAsync("..");
        #endregion
    }
}
