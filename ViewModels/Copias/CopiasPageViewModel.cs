using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.Views.Copias;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;

namespace AutomatizacionServicios.ViewModels.Copias
{
    public partial class CopiasPageViewModel : BaseViewModel
    {

        readonly CService getPost = new CService();

        private List<CopiaseImpresionesResponse> copias;
     
        public ObservableCollection<CopiaseImpresionesResponse> LstCopias { get; set; } = new ObservableCollection<CopiaseImpresionesResponse>();

        #region Properties

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
                    Seleccion().ConfigureAwait(false);
                }

            }
        }

        [ObservableProperty]
        private bool btnAddVisible;

        #endregion

        public CopiasPageViewModel()
        {
            BtnAddVisible = App.UserInfoDetails.Tipo_usuario_id == "2" ? true : false;
            AddServList();
        }

        private void AddServList()
        {
            LstCopias.Clear();
            //List<CopiaseImpresionesResponse> copias = new List<CopiaseImpresionesResponse>();

            IsBusy = true;
            Task.Run(async() =>
            {
                //LstCopias.Clear();
                copias = await getPost.CopiaseImpreseionesSrv(App.UserInfoDetails.Facultad_id, App.UserInfoDetails.Tipo_usuario_id);

                /*App.Current.Dispatcher.Dispatch(() =>
                {*/
                    //LstCopias.Clear();
                    try
                    {
                        if (copias !=null) { 
                            foreach(CopiaseImpresionesResponse copia in copias)
                            {
                                LstCopias.Add(copia);
                            }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido actualizar el feed", "OK");
                    }
                    //ObservableCollection<CopiaseImpresionesResponse> copiasItems = new ObservableCollection<CopiaseImpresionesResponse>(await Items(copias));
                    //await Items(copias);
                    //LstCopias = new ObservableCollection<CopiaseImpresionesResponse>(await Items(copias));
                    //LstCopias = copiasItems;
                    //Items(copias).GetAwaiter();
                    }
                    catch (HttpRequestException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido actualizar el feed", "OK");
                    }
                    catch (WebException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Error al conectarse", "OK");
                    }
                //});
                LstState = true;
                IsBusy = false;
            }).ConfigureAwait(false);
            //LstState = true;
            //IsBusy = false;
        }
        //private async Task<CopiaseImpresionesResponse> Items(List<CopiaseImpresionesResponse> items)
        /*async Task<List<CopiaseImpresionesResponse>> Items(List<CopiaseImpresionesResponse> items)
        {
            var listItems = new List<CopiaseImpresionesResponse>();
            var taskCount = items.Count;
            for(int i = 0; i < taskCount; i++)
            {
                //listItems.Add(items[i]) ;
                listItems.Add(items[i]);
            }
            return listItems;
        }*/

        #region Commands
        [RelayCommand]
        void Refresh()
        {
            IsRefreshing = true;
            AddServList();
            IsRefreshing = false;
        }

        async Task Seleccion()
        {
            /*Task.Run(() =>
            {
                Application.Current.Dispatcher.Dispatch(async () =>
                {*/
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
                /*});
            });*/
        }
        #endregion
    }
}
