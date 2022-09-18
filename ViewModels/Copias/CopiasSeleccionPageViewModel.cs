using AutomatizacionServicios.Views.Copias;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Copias
{

    public partial class CopiasSeleccionPageViewModel : BaseViewModel
    {
        private string _user;

        public string User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public CopiasSeleccionPageViewModel()
        {
            User = App.UserInfoDetails.nombre;
        }

        #region Commands
        [RelayCommand]
        async void Volver() => await Shell.Current.GoToAsync("..");
        #endregion
    }
}
