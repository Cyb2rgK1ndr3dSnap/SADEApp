using AutomatizacionServicios.Views.startup;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    { 
        /*
        //#region INotifyPropertyChanged Members
        protected void RaisePropertyChanged(string propertyName)
        => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Set a property and raise a property changed event if it has changed
        /// </summary>
        protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value))
            {
                return false;
            }

            property = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        #region Fields
        private bool _Parametro;
        #endregion
        #region Properties

        public bool Parametro
        {
            get => _Parametro;
            set
            {
                SetProperty(ref _Parametro,value);
                RaisePropertyChanged("Parametro");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        */
        #region Commands
        [RelayCommand]
        async void CerrarSesion()
        {
            if (Preferences.ContainsKey(nameof(App.UserInfoDetails)))
            {
                Preferences.Remove(nameof(App.UserInfoDetails));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        #endregion
    }
}
