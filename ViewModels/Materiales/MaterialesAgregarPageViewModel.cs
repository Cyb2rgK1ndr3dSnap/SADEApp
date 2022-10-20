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
                if (String.IsNullOrEmpty(Otro))
                {
                    Otro = "";
                }
                if (String.IsNullOrWhiteSpace(NombreMaterial))
                {
                    await Application.Current.MainPage.DisplayAlert("No exitoso", "Por favor ingresar datos valídos", "OK");
                }else if (Corta == 1 && Larga == 1)
                {
                    await Application.Current.MainPage.DisplayAlert("No exitoso", "Por favor elegir una opción corta o larga", "OK");
                }else if (Color == 1 && String.IsNullOrWhiteSpace(ColorNombre) || Color == 0 && !String.IsNullOrWhiteSpace(ColorNombre))
                {
                    await Application.Current.MainPage.DisplayAlert("No exitoso", "Por favor ingrese el color de nombre o seleccionar el cuadro color", "OK");
                }
                else
                {
                    response = await getPost.MaterialAdd(NombreMaterial, Otro, ColorNombre, Color, Corta, Larga);
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
            }
            catch (NullReferenceException)
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
