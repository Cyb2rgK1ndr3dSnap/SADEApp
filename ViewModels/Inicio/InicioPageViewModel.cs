using CommunityToolkit.Mvvm.ComponentModel;
using AutomatizacionServicios.Views.Inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Inicio
{
    public partial class InicioPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _apellido;

        [ObservableProperty]
        private string _id;

        public InicioPageViewModel()
        {
            string userInfoDetailsStr = Preferences.Get(nameof(App.UserInfoDetails),"");
            Nombre=App.UserInfoDetails.Nombre;
            Nombre += " " + App.UserInfoDetails.Apellido;
            Apellido = App.UserInfoDetails.Apellido;
            Id = App.UserInfoDetails.Usuario_id.ToString();
        }
           
    }
}
