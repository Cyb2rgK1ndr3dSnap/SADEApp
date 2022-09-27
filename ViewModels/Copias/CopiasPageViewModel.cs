﻿using AutomatizacionServicios.Models;
using AutomatizacionServicios.Services;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Inicio;
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

        readonly LServices getPost = new LServices();

        #region Properties
        public ObservableCollection<CopiaseImpresionesResponse> LstCopias { get; set; } = new ObservableCollection<CopiaseImpresionesResponse>();

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
                        copias = await getPost.CopiaseImpreseionesSer("1", App.UserInfoDetails.Tipo_usuario_id);
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

                    foreach (CopiaseImpresionesResponse usuar in copias)
                    {
                        LstCopias.Add(usuar);
                    }
                    IsBusy = false;
                });
            }
            );
        }

        #endregion

        #region Commands
        [RelayCommand]
        async void Seleccion()
        {
            await Shell.Current.GoToAsync($"{nameof(CopiasSeleccionPage)}",false);
        }
        #endregion
    }
}
