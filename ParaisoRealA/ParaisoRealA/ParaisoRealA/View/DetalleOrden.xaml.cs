using Newtonsoft.Json;
using ParaisoRealA.Model;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleOrden : ContentPage
    {
        public DetalleOrden()
        {
            InitializeComponent();
            var HOLA = this;
            BindingContext = this;
        }

        public DetalleOrden(reservacion reservacionRecibida = null)
           : this()
        {
            ReservacionUsar = reservacionRecibida;
            ObtenerDetalle();

            
        }

        public async void ObtenerDetalle()
        {
            indicatordt.IsRunning = true;
            try
            {

                var cliente2 = new HttpClient();
                string URL = string.Format(Constantes.Base + "/api/detallereservacions/Getdetallereservacion/");// + VerDetalleOrder.idreservacion);
                var miArreglo2 = await cliente2.GetStringAsync(URL);
                var verordenesmu = JsonConvert.DeserializeObject<List<detallereservacion>>(miArreglo2);
                //var nuevalista2 = verordenesmu.Where(a => a.idubicacion == 2 && a.estado == 1);
                List<detallereservacion> nuevalista2 = verordenesmu.Where(a => a.idreservacion == ReservacionUsar.id).ToList();
                
               List<detallereservacion> VerDetalleOrder =  nuevalista2;
                ListDetalle.ItemsSource = nuevalista2;
                var excample = nuevalista2;

                ListDetalle.IsEnabled = true;

            }
            catch (Exception e)
            {
                var variable = e.Message;

                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                ListDetalle.IsEnabled = true;
                indicatordt.IsRunning = false;
                return;
            }
            indicatordt.IsRunning = false;
        }

        public void ListDetalle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        public async void EntregaOrden_Clicked(object sender, EventArgs e)
        {
            indicatordt.IsRunning = true;
            try
            {


                var answer = await DisplayAlert("Mensaje", "Desea Eliminar el Producto", "Si", "No");
                if (answer == true)
                {
                    HttpClient borrarres = new HttpClient();
                    var resultbr = await borrarres.DeleteAsync(string.Concat(Constantes.Base + "/api/reservacions/Deletereservacion/", ReservacionUsar.id));
                    if (resultbr.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Mensaje", "Producto Eliminado con Exito", "OK");

                        await App.Current.MainPage.Navigation.PushAsync(new MasterMenu());
                        totalin.Text = string.Empty;
                       

                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Mensaje", "Operacion Cancelada", "Ok");

                }

                EntregaOrden.IsEnabled = true;
            }
            catch (Exception ef)
            {
                var variable = ef.Message;

                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                ListDetalle.IsEnabled = true;
                indicatordt.IsRunning = false;
                return;
            }
            indicatordt.IsRunning = false;
        }

       

        #region propiedades
        private reservacion _reser;

        public reservacion ReservacionUsar
        {
            get { return _reser; }
            set { _reser = value; OnPropertyChanged(); }
        }


        private detallereservacion _verdetalleorder;

        public detallereservacion VerDetalleOrder
        {
            get { return _verdetalleorder; }
            set { _verdetalleorder = value; OnPropertyChanged(); }
        }

        private List<detallereservacion> _detalleproperty;

        public List<detallereservacion> Detalleproperty
        {
            get { return _detalleproperty; }
            set { _detalleproperty = value; OnPropertyChanged(); }
        }


        #endregion

        
    }
}