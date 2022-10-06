using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Inicio;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Copias
{
    public partial class CopiasPageViewModel : BaseViewModel
    {

        readonly CService getPost = new CService();

        #region Properties
        public ObservableCollection<CopiaseImpresionesResponse> LstCopias { get; set; } = new ObservableCollection<CopiaseImpresionesResponse>();

        private CopiaseImpresionesResponse _selectedUsuarios;

        public CopiaseImpresionesResponse SelectedUsuarios
        {
            get => _selectedUsuarios;
            set => SetProperty(ref _selectedUsuarios, value);
        }

        private CopiaseImpresionesResponse _selectedPeticion;

        public CopiaseImpresionesResponse SelectedPeticion
        {
            get => _selectedPeticion;
            set
            {
                if (value != null)
                {
                //No se puede seleccionar elemento del Listview
                LstState = false;
                SetProperty(ref _selectedPeticion, value);
                Seleccion();
                }
                
            }
        }

        //[ObservableProperty]
        //private bool lstState;

        public CopiasPageViewModel()
        {
            AddServList();
        }

        private void AddServList()
        {
            LstCopias.Clear();
            IsBusy = true;
            Task.Run(() =>
            {
                //List<Usuarios> usuarios = await getPost.InfosSer();
                List<CopiaseImpresionesResponse> copias = new List<CopiaseImpresionesResponse>();
                //await Task.Delay(2000);                
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        //##Traer en el objeto el número de facultad a la que pertenece el usuario
                        copias = await getPost.CopiaseImpreseionesSrv(App.UserInfoDetails.Facultad_id, App.UserInfoDetails.Tipo_usuario_id);
                    }
                    catch (HttpRequestException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido actualizar el feed", "OK");
                    }
                    catch (WebException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Error al conectarse", "OK");
                    }

                    await Task.Delay(2000);

                    foreach (CopiaseImpresionesResponse cop in copias)
                    {
                        LstCopias.Add(cop);
                    }
                    IsBusy = false;
                    LstState = true;
                });
            }
            );
        }

        #endregion

        #region Commands
        //[RelayCommand]
        void Seleccion()
        {
            Task.Run(() =>
            {
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync($"{nameof(CopiasSeleccionPage)}",
                    new Dictionary<string, object>
                    {
                        ["SerId"] = _selectedPeticion.Id,
                        ["SerSelect"] = _selectedPeticion.Nombre,
                        ["SerCosto"] = _selectedPeticion.Costo,
                        ["SerColor"] = _selectedPeticion.Color
                    });
                    //Se puede seleccionar nuevamente un elementos del Listview
                    LstState = true;
                });
            });
        }
        #endregion
    }
}
