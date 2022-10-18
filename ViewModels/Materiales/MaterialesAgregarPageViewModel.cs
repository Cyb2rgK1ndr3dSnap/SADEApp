using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Models.Materiales;
using AutomatizacionServicios.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.ViewModels.Materiales
{
    public partial class MaterialesAgregarPageViewModel : BaseViewModel
    {
        MService getPost = new MService();

        #region Properties

        [ObservableProperty]
        private string nombreMaterial;

        [ObservableProperty]
        private string colorNombre;

        [ObservableProperty]
        private string otro;

        [ObservableProperty]
        private int corta;

        [ObservableProperty]
        private int larga;

        [ObservableProperty]
        private int color;

        #endregion

        #region Command
        //ARREGLAR ESTO
        [RelayCommand]
        async Task Realizar()
        {
            MaterialesAddResponse response = new MaterialesAddResponse();
            try
            {
                if (!String.IsNullOrWhiteSpace(NombreMaterial))
                {
                    if (Corta==1 && Larga==1)
                    {
                        if (Color == 1 && String.IsNullOrWhiteSpace(ColorNombre))
                        {
                            response = await getPost.MaterialAdd(NombreMaterial,Otro,ColorNombre,Color, Corta, Larga);
                            if (response.ErrorInfo != null)
                            {
                                await Application.Current.MainPage.DisplayAlert("Sin exito", response.ErrorInfo[2], "OK");
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Exitoso", response.Message, "OK");
                                await Shell.Current.GoToAsync("..");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("No exitoso", "Por favor elegir una opción corta o larga", "OK");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("No exitoso", "Por favor elegir una opción corta o larga", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("No exitoso", "Por favor ingresar datos valídos", "OK");
                }
            }
            catch (IOException)
            {
                await Application.Current.MainPage.DisplayAlert("No exitoso", "Error contactesé con el administrador", "OK");
            }
        }

        [RelayCommand]
        async Task Cancelar()
        {
            await Shell.Current.GoToAsync("..");
        }

        #endregion
    }
}
