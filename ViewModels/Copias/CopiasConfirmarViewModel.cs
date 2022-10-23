using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;

namespace AutomatizacionServicios.ViewModels.Copias
{
    public partial class CopiasConfirmarViewModel : BaseViewModel
    {
        readonly CService getPost = new CService();

        private List<CopiaseImpresionesRegistrosResponse> registros;

        #region Properties
        public ObservableCollection<CopiaseImpresionesRegistrosResponse> LstRegistros { get; set; } = new ObservableCollection<CopiaseImpresionesRegistrosResponse>();

        //ObservableCollection<CopiaseImpresionesRegistrosResponse> LstRegistro { get; set; } = new ObservableCollection<CopiaseImpresionesRegistrosResponse>();

        private CopiaseImpresionesRegistrosResponse _selectedRegistro;

        public CopiaseImpresionesRegistrosResponse SelectedRegistro
        {
            get => _selectedRegistro;
            set
            {
                SetProperty(ref _selectedRegistro, value);
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

        void AddUserList()
        {
            LstRegistros.Clear();
            IsBusy = true;
            Task.Run(async() =>
            {
                registros = await getPost.CopiaseImpreseionesRegistrosSrv(App.UserInfoDetails.Facultad_id, App.UserInfoDetails.Api_token);
                //List<CopiaseImpresionesRegistrosResponse> registros = new List<CopiaseImpresionesRegistrosResponse>();
                /*App.Current.MainPage.Dispatcher.Dispatch(() =>
                {*/
                    /*try
                    {
                        registros = await getPost.CopiaseImpreseionesRegistrosSrv(App.UserInfoDetails.Facultad_id, App.UserInfoDetails.Api_token);
                        */

                    try
                    {


                    if (registros != null)
                    {

                    /*CopiaseImpresionesRegistrosResponse registro;
                    Parallel.ForEach(registros, registro =>
                    {
                        LstRegistros.Add(registro);
                    });*/
                    
                
                        foreach (var registro in registros)
                        {
                            //App.Current.Dispatcher.DispatchAsync(() => { LstRegistros.Add(registro); })
                            //;
                            //Application.Current.Dispatcher.Dispatch(new Action(() => this.LstRegistros.Add(registro))).ToVisibility();
                            //await Task.Run(() =>
                            //{
                                LstRegistros.Add(registro);
                            //}).ConfigureAwait(false);
                        }
                    }
                    //LstRegistros = LstRegistro;

                        else
                            {
                                await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No existen pedidos en este momento", "OK");
                            }
                        }
                        catch (HttpRequestException)
                        {
                            await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No existen pedidos en este momento", "OK");
                        }
                        catch (WebException)
                        {
                            await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Error al conectarse", "OK");
                        }
                //});
                IsBusy = false;
            });
            //IsBusy = false;
        }

        #region Commands

        [RelayCommand]
        void Refresh()
        {
            IsRefreshing = true;
            AddUserList();
            IsRefreshing = false;
            //return Task.CompletedTask;
        }

        /*
        [RelayCommand]
        async Task Realizar()
        {
            var tmp = SelectedRegistro;
            LstRegistros.RemoveAt(0);
        }*/

        [RelayCommand]
        async Task Cancelar()
        {
            var a = LstRegistros.IndexOf(SelectedRegistro);
            await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Error al conectarse", "OK");
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
