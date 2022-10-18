/* Cambio no fusionado mediante combinación del proyecto 'AutomatizacionServicios (net6.0-ios)'
Antes:
using AutomatizacionServicios.Views.Inicio;
Después:
using CommunityToolkit.Mvvm.ComponentModel;
*/

/* Cambio no fusionado mediante combinación del proyecto 'AutomatizacionServicios (net6.0-windows10.0.19041.0)'
Antes:
using AutomatizacionServicios.Views.Inicio;
Después:
using CommunityToolkit.Mvvm.ComponentModel;
*/

/* Cambio no fusionado mediante combinación del proyecto 'AutomatizacionServicios (net6.0-maccatalyst)'
Antes:
using AutomatizacionServicios.Views.Inicio;
Después:
using CommunityToolkit.Mvvm.ComponentModel;
*/

using AutomatizacionServicios.Models.Token;
using AutomatizacionServicios.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AutomatizacionServicios.ViewModels.Inicio
{
    public partial class InicioPageViewModel : BaseViewModel
    {
        TService IGetPost = new TService();

        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _apellido;

        [ObservableProperty]
        private string billetera;

        public InicioPageViewModel()
        {
            Nombre = App.UserInfoDetails.Nombre;

            ServBilletera();
        }

        async Task ServBilletera()
        {
            await Task.Run(async () =>
            {   
                BilleteraResponse billeteraResponse = new BilleteraResponse();
                billeteraResponse = await IGetPost.Billetera();
                Billetera = billeteraResponse.Dinero;
            });
        }
    }
}
