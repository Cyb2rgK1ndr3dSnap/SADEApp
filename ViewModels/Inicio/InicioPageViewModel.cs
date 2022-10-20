using AutomatizacionServicios.Models.Token;
using AutomatizacionServicios.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AutomatizacionServicios.ViewModels.Inicio
{
    public partial class InicioPageViewModel : BaseViewModel
    {
        readonly TService IGetPost = new TService();

        //private BilleteraResponse billeteraResponse;

        [ObservableProperty]
        private string _nombre;

        [ObservableProperty]
        private string _apellido;

        [ObservableProperty]
        private string billetera;

        public InicioPageViewModel()
        {
            Nombre = App.UserInfoDetails.Nombre;
            //ServBilletera().GetAwaiter();
            ServBilletera();
        }

        void ServBilletera()
        {
            Task.Run(async() =>
            {
                 /*Application.Current.Dispatcher.Dispatch(async () =>
                {*/
                BilleteraResponse billeteraResponse = new BilleteraResponse();
                billeteraResponse = await IGetPost.Billetera();
                Billetera = billeteraResponse.Dinero;
                //});
            }).ConfigureAwait(false);
        }
    }
}
