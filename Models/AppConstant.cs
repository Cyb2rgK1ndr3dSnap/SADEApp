using AutomatizacionServicios.Controls;
using AutomatizacionServicios.Views.Copias;
using AutomatizacionServicios.Views.Dispositivos;
using AutomatizacionServicios.Views.Inicio;
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

            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

            if (App.UserInfoDetails.Tipo_usuario_id == "3")
            {
                permissionDocument = false;
            }
            else
            {
                permissionDocument = true;
            }

            var inicioInfo = AppShell.Current.Items.Where(f => f.Route == nameof(InicioPage)).FirstOrDefault();
            if (inicioInfo != null) AppShell.Current.Items.Remove(inicioInfo);

            //if (App.UserInfoDetails.tipo_usuario_id == "3")
            //{

            var tabPrueba = new FlyoutItem()
            {
                Title = "Home",
                Route = nameof(DispositivosPage),
                IsVisible = true,
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
            {
                new Tab
                {
                    Route="DispositivosPage",
                    Items =
                    {
                        new ShellContent
                        {
                            Title = "Home",
                            Route = "DispositivosPage",
                            ContentTemplate = new DataTemplate(typeof(DispositivosPage))
                        },
                        new ShellContent
                        {
                            Title = "Home",
                            Route = "DispositivosPage",
                            ContentTemplate = new DataTemplate(typeof(DispositivosPage))
                        }
                    }
                }
            }
            };

            /////////////////////////////////////////////////////////

            var flyoutItem = new FlyoutItem()
                {
                    Route = nameof(InicioPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                                {
                                    new ShellContent
                                    {
                                        Icon = "house.png",
                                        Title = "Inicio",
                                        Route="InicioPage",
                                        ContentTemplate = new DataTemplate(typeof(InicioPage)),
                                    },
                                    new ShellContent
                                    {
                                        Icon = "document.png",
                                        Title = "Copias e Impresiones",
                                        Route="CopiasImpresionesPage",
                                        //IsVisible = permissionDocument,
                                        ContentTemplate = new DataTemplate(typeof(CopiasPage)),
                                    }
                                    ,
                                    new ShellContent
                                    {
                                        Icon = "devices_icon.png",
                                        Title = "Dispositivos",
                                        Route="DispositivosPage",
                                        ContentTemplate = new DataTemplate(typeof(DispositivosPage)),
                                    }                     
                                }
                };
            //

            var tab = new Tab()
            {
                Route = "DispositivosPage",

                //IsVisible = true,
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    
                            new ShellContent
                            {
                                Title="Prueba1",
                                
                                ContentTemplate = new DataTemplate(typeof(DispositivosPage)),
                            },
                            new ShellContent
                            {
                                Title="Prueba2",

                                ContentTemplate = new DataTemplate(typeof(DispositivosPage)),
                                
                            },
                            new ShellContent
                            {
                                Title = "Prueba3",
                                FlyoutItemIsVisible=true,
                                ContentTemplate = new DataTemplate(typeof(DispositivosPage)),
                            }
                        

                },
            };

            //Flyout que se le presenta al usuario al entrar y loguearse correctamente

            var flyoutItemP = new FlyoutItem()
            {
                Route = "InicioPage",
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Items =
                {
                    new Tab
                    {
                        Icon = "house.png",
                        Title="Inicio",
                        Items =
                        {
                            new ShellContent
                                    {
                                        Icon = "house.png",
                                        Title = "Inicio",
                                        Route="InicioPage",
                                        ContentTemplate = new DataTemplate(typeof(InicioPage)),
                                    },
                        }
                    },
                    new Tab
                    {
                        Icon = "document.png",
                        Title="Copias",
                        Items =
                        {
                            new ShellContent
                                    {
                                        FlyoutIcon = "document.png",
                                        Title = "Peticiones",
                                        Route="CopiasImpresionesPage",
                                        //IsVisible = permissionDocument,
                                        ContentTemplate = new DataTemplate(typeof(CopiasPage)),
                                    },
                            new ShellContent
                                    {
                                        FlyoutIcon = "document.png",
                                        Title = "Confirmarciones",
                                        Route="CopiasConfirmarPage",
                                        //IsVisible = permissionDocument,
                                        ContentTemplate = new DataTemplate(typeof(CopiasConfirmarPage)),
                                        MenuItems =
                                        {
                                            new MenuItem
                                            {
                                                Text="ADD"
                                            }
                                        }
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
