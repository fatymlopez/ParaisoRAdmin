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
	public partial class VerProductos : ContentPage
	{
		public VerProductos ()
		{
			InitializeComponent ();
            GetProductos();
		}

        public async  void GetProductos()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(Constantes.Base + "/api/productoss/Getproductos");
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(response);
            ListProducts.ItemsSource = verproductos;      
        }

        public async void ListProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new VerDetalleP { BindingContext = e.SelectedItem });
            }
        }

        public async void SearchProducts_TextChanged(object sender, TextChangedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(Constantes.Base +"/api/productoss/Getproductos");
            var verprodu = JsonConvert.DeserializeObject<List<productos>>(response);
            ListProducts.ItemsSource = verprodu;


            ListProducts.BeginRefresh();

            
           
                //if (string.IsNullOrWhiteSpace(e.NewTextValue))
                //ListProducts.ItemsSource = verprodu;
                //else
                //ListProducts.ItemsSource = verprodu.Where(i => i.nomproducto.Contains(e.NewTextValue));


                ListProducts.EndRefresh();

        }
           

    }
}