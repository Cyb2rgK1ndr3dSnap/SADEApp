using AutomatizacionServicios.Models.CopiasEImpresiones;
using AutomatizacionServicios.Models.Token;
using AutomatizacionServicios.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;

namespace AutomatizacionServicios.ViewModels.Copias
{
    [QueryProperty(nameof(SerSelect), nameof(SerSelect))]
    [QueryProperty(nameof(SerCosto), nameof(SerCosto))]
    [QueryProperty(nameof(SerId), nameof(SerId))]
    [QueryProperty(nameof(SerColor), nameof(SerColor))]
    public partial class CopiasSeleccionPageViewModel : BaseViewModel
    {
        readonly CService getPost = new CService();
        readonly TService bGetPost = new TService();

        public ObservableCollection<CopiaseImpresionesHojasResponse> PkrHojas { get; set; } = new ObservableCollection<CopiaseImpresionesHojasResponse>();
        //

        [ObservableProperty]
        public string serSelect;

        [ObservableProperty]
        public string serId;

        [ObservableProperty]
        public decimal serCosto;

        [ObservableProperty]
        public int serColor;

        [ObservableProperty]
        private string materialCopiado;

        [ObservableProperty]
        private decimal precio;

        [ObservableProperty]
        private bool flag;

        [ObservableProperty]
        private string billetera;

        private CopiaseImpresionesHojasResponse _selectedItem;

        public CopiaseImpresionesHojasResponse SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    //No se puede seleccionar elemento del Listview
                    LstState = false;
                    SetProperty(ref _selectedItem, value);
                    Disponible = "Disponible: " + _selectedItem.Cantidad_disponible + " hojas";
                }

            }
        }

        [ObservableProperty]
        private string disponible;

        private string cantidad;

        public string Cantidad
        {
            get => cantidad;
            set
            {
                //Validaciones de una manera dinámica de que se calcule solo cuando sean números
                value = !value.ToCharArray().All(Char.IsDigit) ? "0" : value;
                value = String.IsNullOrWhiteSpace(value) ? "0" : value;
                value = int.Parse(value) <= 10000 ? value : "10000";
                SetProperty(ref cantidad, value);
                Precio = int.Parse(Cantidad) < 0 ? 0 : (serCosto * int.Parse(Cantidad));
            }
        }

        [ObservableProperty]
        private string _user;

        [ObservableProperty]
        private string _identificacion;

        public CopiasSeleccionPageViewModel()
        {
            User = App.UserInfoDetails.Nombre;
            Identificacion = App.UserInfoDetails.Cedula;
            AddHojas();
            ServBilletera();
        }

        private void AddHojas()
        {
            Task.Run(() =>
            {
                List<CopiaseImpresionesHojasResponse> hojas = new List<CopiaseImpresionesHojasResponse>();
                Application.Current.Dispatcher.Dispatch(async () =>
                {
                    PkrHojas.Clear();
                    try
                    {
                        //##Traer en el objeto el número de facultad a la que pertenece el usuario
                        hojas = await getPost.CopiaseImpreseionesHojasSrv(App.UserInfoDetails.Facultad_id);

                        await Task.Delay(500);
                        //PONER VALIDACIOENS AQUÍ PARA QUE HAYA ERROR POR NULL EXCEPTION Y EN TODAS LAS DEMÁS TAMBIÉN

                        try
                        {
                            foreach (CopiaseImpresionesHojasResponse hoj in hojas)
                            {
                                PkrHojas.Add(hoj);
                            }
                        }
                        catch (NullReferenceException)
                        {
                            await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido cargar las hojas", "OK");
                        }

                    }
                    catch (HttpRequestException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "No se ha podido actualizar las hojas", "OK");
                    }
                    catch (WebException)
                    {
                        await Application.Current.MainPage.DisplayAlert("Connection Problem 500", "Error al cargar hojas", "OK");
                    }
                });
            }
            );
        }

        void ServBilletera()
        {
            Task.Run(async () =>
            {
                BilleteraResponse billeteraResponse = new BilleteraResponse();
                billeteraResponse = await bGetPost.Billetera();
                Billetera = billeteraResponse.Dinero;
            });
        }

        #region Commands
        /*[RelayCommand]
        async void ScannerId()
        {
            Identificacion = "";
        }*/


        [RelayCommand]
        async Task Realizar()
        {
            //flag = Programar la lógica para validar que todos los datos no estén nulos;
            CopiaseImpresionesInsertRegisterResponse response = new CopiaseImpresionesInsertRegisterResponse();
            try
            {
                if (!String.IsNullOrWhiteSpace(Cantidad) && !String.IsNullOrWhiteSpace(MaterialCopiado) && !String.IsNullOrWhiteSpace(Precio.ToString()) && SelectedItem != null && Int32.Parse(Cantidad) > 0 && Cantidad.ToCharArray().All(Char.IsDigit))
                {

                    response = await getPost.CopiaseImpreseionesInsertRegistroSrv(App.UserInfoDetails.Facultad_id, _selectedItem.Material_Id, MaterialCopiado, SerColor, SerId, Int32.Parse(Cantidad), Precio);
                    if (response.ErrorInfo != null)
                    {
                        AddHojas();
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
                    await Application.Current.MainPage.DisplayAlert("No exitoso", "Por favor ingresar datos valídos", "OK");
                }
            }
            catch (IOException)
            {
                AddHojas();
                await Application.Current.MainPage.DisplayAlert("No exitoso", "Error contactesé con el administrador", "OK");
            }
        }

        [RelayCommand]
        async Task Cancelar() => await Shell.Current.GoToAsync("..");
        #endregion
    }
}
