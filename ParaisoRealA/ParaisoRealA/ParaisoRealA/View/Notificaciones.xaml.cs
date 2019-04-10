using Newtonsoft.Json;
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
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/ordens/Getorden");
            var miArreglo = await client.GetStringAsync(URL);
            var verordenes = JsonConvert.DeserializeObject<List<orden>>(miArreglo);
            var nuevalista = verordenes.Where(a => a.idubicacion == 1 && a.estado == 1);
            ListNotificaciones.ItemsSource = nuevalista;



        }

        public async void MUNIVO_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/ordens/Getorden");
            var miArreglo = await client.GetStringAsync(URL);
            var verordenes = JsonConvert.DeserializeObject<List<orden>>(miArreglo);
            var nuevalista = verordenes.Where(a => a.idubicacion == 2 && a.estado == 1);
            ListNotificaciones.ItemsSource = nuevalista;
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