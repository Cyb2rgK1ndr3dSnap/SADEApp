using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Models.Materiales;
using AutomatizacionServicios.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Materiales
{
    public partial class MaterialesPageViewModel : BaseViewModel
    {
        readonly MService getPost = new MService();

        public ObservableCollection<MaterialesResponse> LstMateriales { get; set; }= new ObservableCollection<MaterialesResponse>();

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
                        materiales = await getPost.AddMateriales();

                        await Task.Delay(1000);

                        try
                        {
                            foreach (MaterialesResponse material in materiales)
                            {
                                LstMateriales.Add(material);
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
    }
}
