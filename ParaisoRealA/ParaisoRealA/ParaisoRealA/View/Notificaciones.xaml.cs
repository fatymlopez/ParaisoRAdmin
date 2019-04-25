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

        public async void CDUNIVO_Clicked(object sender, EventArgs e)
        {
            var cliente = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/reservacions/Getreservacion");
            var miArreglo1 = await cliente.GetStringAsync(URL);
            var verordenesuni = JsonConvert.DeserializeObject<List<reservacion>>(miArreglo1);
            var nuevalista1 = verordenesuni.Where(a => a.idubicacion == 1 && a.estado == 1);
            ListNotificaciones.ItemsSource = nuevalista1;
        }

        public async void MUNIVO_Clicked(object sender, EventArgs e)
        {
            var cliente2 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/reservacions/Getreservacion");
            var miArreglo2 = await cliente2.GetStringAsync(URL);
            var verordenesmu = JsonConvert.DeserializeObject<List<reservacion>>(miArreglo2);
            var nuevalista2 = verordenesmu.Where(a => a.idubicacion == 2 && a.estado == 1);
            ListNotificaciones.ItemsSource = nuevalista2;
        }

        public async void UMAA_Clicked(object sender, EventArgs e)
        {

        }

        public async void ListNotificaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
             
                await App.Current.MainPage.Navigation.PushAsync(new DetalleOrden { BindingContext = e.SelectedItem });
            }
        }

        
    }
}