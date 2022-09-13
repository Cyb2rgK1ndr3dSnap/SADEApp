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
            Nombre=App.UserInfoDetails.nombre;
            Nombre += " " + App.UserInfoDetails.apellido;
            Apellido = App.UserInfoDetails.apellido;
            Id = App.UserInfoDetails.usuario_id.ToString();
        }
           
    }
}
