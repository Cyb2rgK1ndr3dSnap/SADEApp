using AutomatizacionServicios.Models.Materiales;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.Views.Materiales;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;

namespace AutomatizacionServicios.ViewModels.Materiales
{
    public partial class MaterialesPageViewModel : BaseViewModel
    {
        readonly MService getPost = new MService();

        private List<MaterialesResponse> materiales = new List<MaterialesResponse>();

        public ObservableCollection<MaterialesResponse> LstMateriales { get; set; } = new ObservableCollection<MaterialesResponse>();

        private MaterialesResponse selectedMaterial;

        public MaterialesResponse SelectedMaterial
        {
            get => selectedMaterial;
            set
            {
                if (value != null)
                {
                    //No se puede seleccionar elemento del Listview
                    LstState = false;
                    SetProperty(ref selectedMaterial, value);
                    //Seleccion();
                }

            }
        }

        public MaterialesPageViewModel()
        {
            //AddMaterialesList().GetAwaiter();
            AddMaterialesList();
        }

        void AddMaterialesList()
        {
            LstMateriales.Clear();
            //List<MaterialesResponse> materiales = new List<MaterialesResponse>(); 
            IsBusy = true;
            Task.Run(async() =>
            {
                /*App.Current.Dispatcher.Dispatch(async() =>
                {*/
                    try { 
                    materiales = await getPost.MaterialesServ();
                    /*try
                        {*/
                    if (materiales != null)
                    {
                        foreach (MaterialesResponse material in materiales)
                        {
                            LstMateriales.Add(material);
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido actualizar el feed", "OK");
                    }   
                        //await Items(materiales);
                        /*var taskCount = materiales.Count;
                        for (int i = 0; i < taskCount; i++)
                        {
                            this.LstMateriales.Add(materiales[i]);
                        }
                        LstState = true;
                        IsBusy = false;*/
                    }
                    catch (HttpRequestException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido actualizar el feed", "OK");
                    }
                    catch (WebException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Error al conectarse", "OK");
                    }
                    LstState = true;
                //});
                IsBusy = false;
            });
            //IsBusy = false;
        }

        /*
        private async Task Items(List<MaterialesResponse> items)
        {
            //CopiaseImpresionesResponse item = new CopiaseImpresionesResponse();
            var taskCount = items.Count;
            for (int i = 0; i < taskCount; i++)
            {
                this.LstMateriales.Add(items[i]);
            }
            //return await Task.FromResult(item);
        }*/

        #region Command
        [RelayCommand]
        void Refresh()
        {
            IsRefreshing = true;
            AddMaterialesList();
            IsRefreshing = false;
            //return Task.CompletedTask;
        }

        [RelayCommand]
        async Task Agregar()
        {
            await Shell.Current.GoToAsync($"{nameof(MaterialesAgregarPage)}");
        }
        #endregion
    }
}
