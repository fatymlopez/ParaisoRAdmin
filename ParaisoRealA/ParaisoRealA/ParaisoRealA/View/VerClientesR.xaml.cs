using Newtonsoft.Json;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections;
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
	public partial class VerClientesR : ContentPage
	{
  
        public VerClientesR ()
		{
			InitializeComponent ();
            GetListCliente();
        }

        public async void GetListCliente()
        {
            HttpClient client = new HttpClient();
            
            var response = await client.GetStringAsync("http://paraisoreal19.somee.com/api/clientes/Getcliente");
            var vercliente = JsonConvert.DeserializeObject<List<cliente>>(response);
            ClienteListView.ItemsSource = vercliente;
        }

        public async void ClienteListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new VerDetalleCli { BindingContext = e.SelectedItem });
            }
        }
    }
}