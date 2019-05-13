﻿using Newtonsoft.Json;
using ParaisoRealA.Model;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealA.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Notificaciones : ContentPage
	{
		public Notificaciones ()
		{
			InitializeComponent ();
            
		}
        //nuevo prueba
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Mensaje", "Desea salir de la Aplicacion", "SI", "NO");

                if (true)
                {

                    Constantes.idusuario = 0;
                    Constantes.usuario = "";
                    Constantes.contraseña = "";
                    Constantes.nombreu = "";
                    await Navigation.PopAsync();

                }

               

            });
            return base.OnBackButtonPressed();
            //return true;
        }
        
        public async void CDUNIVO_Clicked(object sender, EventArgs e)
        {
            indicatorsu.IsRunning = true;
            try
            {

                var cliente = new HttpClient();
                string URL = string.Format(Constantes.Base + "/api/reservacions/Getreservacion");
                var miArreglo1 = await cliente.GetStringAsync(URL);
                var verordenesuni = JsonConvert.DeserializeObject<List<reservacion>>(miArreglo1);
                var nuevalista1 = verordenesuni.Where(a => a.idubicacion == 1 && a.estado == 0);
                ListNotificaciones.ItemsSource = nuevalista1;

                CDUNIVO.IsEnabled = true;

            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                CDUNIVO.IsEnabled = true;
                indicatorsu.IsRunning = false;
                return;
            }

            indicatorsu.IsRunning = false;
        }

        public async void MUNIVO_Clicked(object sender, EventArgs e)
        {
            indicatorsu.IsRunning = true;
            try

            {
            var cliente2 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/reservacions/Getreservacion");
            var miArreglo2 = await cliente2.GetStringAsync(URL);
            var verordenesmu = JsonConvert.DeserializeObject<List<reservacion>>(miArreglo2);
            var nuevalista2 = verordenesmu.Where(a => a.idubicacion == 2 && a.estado == 0);
            ListNotificaciones.ItemsSource = nuevalista2;

                MUNIVO.IsEnabled = true;

            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                MUNIVO.IsEnabled = true;
                indicatorsu.IsRunning = false;
                return;
            }
            indicatorsu.IsRunning = false;
        }

        public async void UMAA_Clicked(object sender, EventArgs e)
        {
            indicatorsu.IsRunning = true;
            try
            {

            var cliente3 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/reservacions/Getreservacion");
            var miArreglo3 = await cliente3.GetStringAsync(URL);
            var verordenesmu = JsonConvert.DeserializeObject<List<reservacion>>(miArreglo3);
            var nuevalista3 = verordenesmu.Where(a => a.idubicacion == 3 && a.estado == 0);
            ListNotificaciones.ItemsSource = nuevalista3;

                UMAA.IsEnabled = true;

            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                MUNIVO.IsEnabled = true;
                indicatorsu.IsRunning = false;
                return;
            }
            indicatorsu.IsRunning = false;
        }

        public async void ListNotificaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {

                reservacion objetoseleccionado = (reservacion)e.SelectedItem;
                await App.Current.MainPage.Navigation.PushAsync(new DetalleOrden(objetoseleccionado) { BindingContext = e.SelectedItem });
            }
        }

        
    }
}