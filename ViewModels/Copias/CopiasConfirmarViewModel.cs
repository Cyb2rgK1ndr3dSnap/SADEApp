using AutomatizacionServicios.Models;
using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.Views.Copias;
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
    public partial class CopiasConfirmarViewModel : BaseViewModel
    {
        readonly CService getPost = new CService();

        #region Properties
        public ObservableCollection<CopiaseImpresionesRegistrosResponse> LstRegistros { get; set; } = new ObservableCollection<CopiaseImpresionesRegistrosResponse>();

        private CopiaseImpresionesRegistrosResponse _selectedRegistro;

        public CopiaseImpresionesRegistrosResponse SelectedRegistro
        {
            get => _selectedRegistro;
            set 
            {
                //if (_selectedPeticion != value)
                //{
                    SetProperty(ref _selectedRegistro, value);
                //}

                //SelectItem(_selectedPeticion);

            }
        }

        #endregion

        [ObservableProperty]
        private string stateImage;

        [ObservableProperty]
        private string statePrueba;

        public CopiasConfirmarViewModel()
        {
            AddUserList();
        }

        async Task AddUserList()
        {
            LstRegistros.Clear();
            IsBusy = true;
            await Task.Run(() =>
            {   
                //List<Usuarios> usuarios = await getPost.InfosSer();
                List<CopiaseImpresionesRegistrosResponse> registros = new List<CopiaseImpresionesRegistrosResponse>();
                //await Task.Delay(2000);                
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        registros = await getPost.CopiaseImpreseionesRegistrosSrv(App.UserInfoDetails.Facultad_id,App.UserInfoDetails.Usuario_id);

                        await Task.Delay(500);

                        try
                        {
                            foreach (CopiaseImpresionesRegistrosResponse registro in registros)
                            {
                                if (registro.Tarea=="1")
                                {
                                    registro.StateImage = "ok.png";
                                }
                                else
                                {
                                    registro.StateImage = "nook.png";
                                }
                                LstRegistros.Add(registro);

                            }
                            
                        }
                        catch (ArgumentNullException)
                        {
                            await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No existen pedidos en este momento", "OK");
                        }
                        
                    }
                    catch (HttpRequestException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500","No se ha podido actualizar el feed","OK");
                    }
                    catch (WebException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500","Error al conectarse","OK");
                    }
                });
            }
            );
            IsBusy = false;
        }

        #region Commands

        [RelayCommand]
        async Task Refresh()
        {
            IsRefreshing=true;
            await AddUserList();
            IsRefreshing = false;
        }

        #endregion
        /*
        async Task SelectItem(Usuarios data)
        {
            if (data != null)
            await Shell.Current.GoToAsync($"{nameof(CopiasConfirmarSeleccionPage)}?IdSelect={data.Cedula}");
        }*/

    }
}
