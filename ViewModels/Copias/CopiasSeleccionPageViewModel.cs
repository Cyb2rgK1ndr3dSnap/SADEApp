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
    [QueryProperty(nameof(SerCosto), nameof(SerCosto))]
    [QueryProperty(nameof(SerId), nameof(SerId))]
    [QueryProperty(nameof(SerColor), nameof(SerColor))]
    public partial class CopiasSeleccionPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        public string serSelect;

        [ObservableProperty]
        public string serId;

        [ObservableProperty]
        public decimal serCosto;

        [ObservableProperty]
        public decimal serColor;

        [ObservableProperty]
        private decimal precio;

        [ObservableProperty]
        private bool flag;

        [ObservableProperty]
        private string rdbSelection;

        [ObservableProperty]
        private string rdbTamano;

        private string cantidad;

        public string Cantidad
        {
            get => cantidad;
            set
            {
                //Validaciones de una manera dinámica de que se calcule solo cuando sean números
                value = value.ToCharArray().All(Char.IsDigit) ? value : "0";
                value = String.IsNullOrWhiteSpace(value) ? "0" : value;
                value = int.Parse(value) <= 10000 ? value : "10000";
                SetProperty(ref cantidad, value);
                Precio = int.Parse(Cantidad) < 0 ? 0 : (serCosto * int.Parse(Cantidad));
            }
        }

        [ObservableProperty]
        private string _user;

        [ObservableProperty]
        private string _identificacion;

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
        async Task Realizar()
        {
            var a = RdbSelection;
            var b = RdbTamano;
            var c = RdbTamano;
            //flag = RdbSelection;
        }
        
        [RelayCommand]
        async Task Cancelar() => await Shell.Current.GoToAsync("..");
        #endregion
    }
}
