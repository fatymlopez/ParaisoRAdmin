using Newtonsoft.Json;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ParaisoRealA.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealA.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerClientesR : ContentPage
	{
  
        public VerClientesR ()
		{
			InitializeComponent ();
            GetListCliente();
        }

        public async void GetListCliente()
        {
            indicatorusu.IsRunning = true;
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(Constantes.Base + "/api/clientes/Getcliente");
                var vercliente = JsonConvert.DeserializeObject<List<cliente>>(response);
                ClienteListView.ItemsSource = vercliente;

                ClienteListView.IsEnabled = true;
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                ClienteListView.IsEnabled = true;
                indicatorusu.IsRunning = false;
                return;
            }

            indicatorusu.IsRunning = false;
        }

        public void ClienteListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            
        }

        public async void SearchClientes_TextChanged(object sender, TextChangedEventArgs e)
        {
            HttpClient clientesearch = new HttpClient();
            var response = await clientesearch.GetStringAsync(Constantes.Base + "/api/clientes/Getcliente");
            var verclientes = JsonConvert.DeserializeObject<List<cliente>>(response);
            var ListClient = verclientes.Where(i => i.nombrecl.Contains(e.NewTextValue));

            ClienteListView.ItemsSource = ListClient;
            ClienteListView.BeginRefresh();
            ClienteListView.EndRefresh();

        }
    }
}