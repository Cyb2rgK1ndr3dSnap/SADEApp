using AutomatizacionServicios.Controls;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Dispositivos;
using AutomatizacionServicios.Views.Inicio;
using AutomatizacionServicios.Views.Materiales;
using AutomatizacionServicios.Views.startup;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionServicios.Models
{
    public class AppConstant
    {
        private static bool permissionDocument;

        public bool PermissionDocument { get; set; }

        public async static Task AddFlyoutMenusDetails()
        {

            //AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

            if (App.UserInfoDetails.Tipo_usuario_id == "2" || App.UserInfoDetails.Tipo_usuario_id == "3")
            {
                permissionDocument = true;
            }
            else
            {
                permissionDocument = false;
            }

            var inicioInfo = AppShell.Current.Items.Where(f => f.Route == nameof(InicioPage)).FirstOrDefault();
            if (inicioInfo != null) AppShell.Current.Items.Remove(inicioInfo);

            //if (App.UserInfoDetails.tipo_usuario_id == "3")
            //{

            //Flyout que se le presenta al usuario al entrar y loguearse correctamente

            var flyoutItemP = new TabBar()
            {
                Route = "InicioPage",
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    
                            new ShellContent
                                    {
                                        Icon = "house.png",
                                        Title = "Home",
                                        Route="InicioPage",
                                        ContentTemplate = new DataTemplate(typeof(InicioPage)),
                                    },
                        
                    new Tab
                    {
                        Icon = "stationery.png",
                        Title="Materiales",
                        IsVisible=permissionDocument,
                        Items =
                        {
                            new ShellContent
                                    {
                                        Icon = "stationery.png",
                                        Title = "Materiales",
                                        Route="MaterialesPage",
                                        ContentTemplate = new DataTemplate(typeof(MaterialesPage)),
                                    },      
                        }
                    },
                    new Tab
                    {
                        Icon = "document.png",
                        Title="Copias",
                        Items =
                        {
                            /*new ShellContent
                                    {
                                        FlyoutIcon = "document.png",
                                        Title = "Peticiones",
                                        Route="CopiasImpresionesPage",
                                        //IsVisible = permissionDocument,
                                        ContentTemplate = new DataTemplate(typeof(CopiasPage)),      
                                    },*/
                            new ShellContent
                                    {
                                        FlyoutIcon = "document.png",
                                        Title = "Confirmarciones",
                                        Route="CopiasConfirmarPage",
                                        //IsVisible = permissionDocument,
                                        ContentTemplate = new DataTemplate(typeof(CopiasConfirmarPage))
                                    },/*
                            new ShellContent
                                    {
                                        Icon = "document.png",
                                        Title = "Copias Cerradas",
                                        //Route="CopiasImpresionesPage",
                                        //IsVisible = permissionDocument,
                                        //ContentTemplate = new DataTemplate(typeof(CopiasPage)),
                                    },
                            new ShellContent
                                    {
                                        Icon = "document.png",
                                        Title = "Historial",
                                        //Route="CopiasImpresionesPage",
                                        //IsVisible = permissionDocument,
                                        //ContentTemplate = new DataTemplate(typeof(CopiasPage)),
                                    },*/
                        }
                    },
                    /*
                    new Tab
                    {
                        Icon = "devices_icon.png",
                        Title="Dispositivos",
                        Items =
                        {
                            new ShellContent
                                    {
                                        Icon = "devices_icon.png",
                                        Title ="Dispositivos",
                                        Route="DispositivosPage",
                                        ContentTemplate = new DataTemplate(typeof(DispositivosPage)),
                                    },
                            new ShellContent
                                    {
                                
                                        FlyoutIcon = "devices_icon.png",
                                        Icon = "devices_icon",
                                        Title = "Dis2",
                                        Route="RegisterPage",
                                        ContentTemplate = new DataTemplate(typeof(RegisterPage)),
                                        //IsVisible=permissionDocument,
                                        IsVisible=true,
                                    }
                        }
                    },
                    */
                }
            };
            //DE QUÉ ES LA COPIA
            //NOMBRE,AULA,FACULTAD,
            //CONTROL NOMBRE,AULA,HORA DE ENTRADA Y SALIDA; //QUE ATIENDA
            //
            ///////////////////nameof(CopiasImpresionesPage) = tab;

            if (!AppShell.Current.Items.Contains(flyoutItemP))
                {
                AppShell.Current.Items.Add(flyoutItemP);

                if (DeviceInfo.Platform == DevicePlatform.WinUI)
                    {
                        AppShell.Current.Dispatcher.Dispatch(async () =>
                        {
                            await Shell.Current.GoToAsync($"//{nameof(InicioPage)}");
                        });
                    }
                    else
                    {
                        await Shell.Current.GoToAsync($"//{nameof(InicioPage)}");
                    }
                }
            //}
        }
    }
}
