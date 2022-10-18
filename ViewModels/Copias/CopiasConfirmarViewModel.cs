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

        #region Properties
        public ObservableCollection<CopiaseImpresionesRegistrosResponse> LstRegistros { get; set; } = new ObservableCollection<CopiaseImpresionesRegistrosResponse>();

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

        async Task AddUserList()
        {
            LstRegistros.Clear();
            IsBusy = true;
            await Task.Run(() =>
            {
                List<CopiaseImpresionesRegistrosResponse> registros = new List<CopiaseImpresionesRegistrosResponse>();
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        registros = await getPost.CopiaseImpreseionesRegistrosSrv(App.UserInfoDetails.Facultad_id, App.UserInfoDetails.Api_token);
                        //await Task.Delay(500);
                        try
                        {
                            if(registros != null)
                            {
                                foreach (CopiaseImpresionesRegistrosResponse registro in registros)
                                {
                                    LstRegistros.Add(registro);
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No existen pedidos en este momento", "OK");
                            }
                        }
                        catch (NullReferenceException)
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
                });
            }
            );
            IsBusy = false;
        }

        #region Commands

        [RelayCommand]
        async Task Refresh()
        {
            IsRefreshing = true;
            await AddUserList();
            IsRefreshing = false;
        }

        [RelayCommand]
        async Task Realizar()
        {
            var tmp = SelectedRegistro;
            LstRegistros.RemoveAt(0);
        }

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
