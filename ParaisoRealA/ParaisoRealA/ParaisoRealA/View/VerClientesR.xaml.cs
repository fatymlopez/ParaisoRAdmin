using Newtonsoft.Json;
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
	public partial class VerClientesR : ContentPage
	{
		public VerClientesR ()
		{
			InitializeComponent ();
            GetListCliente();

        }

        private async void GetListCliente()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://paraisoreal19.somee.com/api/clientes/Getcliente");
            var Cliente = JsonConvert.DeserializeObject<List<cliente>>(response);
            ClienteListView.ItemsSource = Cliente;
        }
    }
}