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
            AddMaterialesList();
        }

        async Task AddMaterialesList()
        {
            LstMateriales.Clear();
            IsBusy = true;
            await Task.Run(() =>
            {
                //List<Usuarios> usuarios = await getPost.InfosSer();
                List<MaterialesResponse> materiales = new List<MaterialesResponse>();
                //await Task.Delay(2000);                
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        //##Traer en el objeto el número de facultad a la que pertenece el usuario
                        materiales = await getPost.MaterialesServ();

                        await Task.Delay(1000);

                        try
                        {
                            if(materiales != null)
                            {
                                foreach (MaterialesResponse material in materiales)
                                {
                                    LstMateriales.Add(material);
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido cargar el feed", "OK");
                            }
                        }
                        catch (NullReferenceException)
                        {
                            await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido cargar el feed", "OK");
                        }

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
                });
            }
            );
            IsBusy = false;
        }

        #region Command
        [RelayCommand]
        async Task Refresh()
        {
            IsRefreshing = true;
            await AddMaterialesList();
            IsRefreshing = false;
        }

        [RelayCommand]
        async Task Agregar()
        {
            await Shell.Current.GoToAsync($"{nameof(MaterialesAgregarPage)}");
        }
        #endregion
    }
}
