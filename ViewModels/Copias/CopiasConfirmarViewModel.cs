using AutomatizacionServicios.Models;
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
        readonly LServices getPost = new LServices();

        #region Properties
        public ObservableCollection<Usuarios> LstConfirmaciones { get; set; } = new ObservableCollection<Usuarios>();

        private Usuarios _selectedUsuarios;

        public Usuarios SelectedUsuarios
        {
            get => _selectedUsuarios;
            set => SetProperty(ref _selectedUsuarios, value);
        }

        private Usuarios _selectedPeticion;

        public Usuarios SelectedPeticion
        {
            get => _selectedPeticion;
            set 
            {
                //if (_selectedPeticion != value)
                //{
                    SetProperty(ref _selectedPeticion, value);
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
            LstConfirmaciones.Clear();
            IsBusy = true;
            Task.Run(() =>
            {   
                //List<Usuarios> usuarios = await getPost.InfosSer();
                List<Usuarios> usuarios = new List<Usuarios>();
                //await Task.Delay(2000);                
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        usuarios = await getPost.InfosSer();
                    }
                    catch (HttpRequestException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500","No se ha podido actualizar el feed","OK");
                    }
                    catch (WebException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500","Error al conectarse","OK");
                    }

                    await Task.Delay(2000);

                    foreach (Usuarios usuar in usuarios)
                    {
                        LstConfirmaciones.Add(usuar);
                    }
                    IsBusy = false;
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
