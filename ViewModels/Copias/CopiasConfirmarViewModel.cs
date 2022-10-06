using AutomatizacionServicios.Models;
using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.Views.Copias;
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

        private Usuarios _selectedUsuarios;

        public Usuarios SelectedUsuarios
        {
            get => _selectedUsuarios;
            set => SetProperty(ref _selectedUsuarios, value);
        }

        private Usuarios _selectedRegistros;

        public Usuarios SelectedRegistros
        {
            get => _selectedRegistros;
            set 
            {
                //if (_selectedPeticion != value)
                //{
                    SetProperty(ref _selectedRegistros, value);
                //}

                //SelectItem(_selectedPeticion);

            }
        }

        #endregion

        public CopiasConfirmarViewModel()
        {
            AddUserList();
        }

        private void AddUserList()
        {
            LstRegistros.Clear();
            IsBusy = true;
            Task.Run(() =>
            {   
                //List<Usuarios> usuarios = await getPost.InfosSer();
                List<CopiaseImpresionesRegistrosResponse> registros = new List<CopiaseImpresionesRegistrosResponse>();
                //await Task.Delay(2000);                
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        registros = await getPost.CopiaseImpreseionesRegistrosSrv(App.UserInfoDetails.Facultad_id,App.UserInfoDetails.Usuario_id);

                        await Task.Delay(2000);

                        foreach (CopiaseImpresionesRegistrosResponse registro in registros)
                        {
                            LstRegistros.Add(registro);
                        }
                        IsBusy = false;
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
        }
        /*
        async Task SelectItem(Usuarios data)
        {
            if (data != null)
            await Shell.Current.GoToAsync($"{nameof(CopiasConfirmarSeleccionPage)}?IdSelect={data.Cedula}");
        }*/
        
    }
}
