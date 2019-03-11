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
            var response = await client.GetStringAsync("http://paraisoreal19.somee.com/api/productoss/Getproductos");
            var verproductos = JsonConvert.DeserializeObject<List<productos>>(response);
            ListProducts.ItemsSource = verproductos;
        }

        public async void ListProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                //esto es para que en vez que aparesca idcategoria aparesca el nombre
               // HttpClient clients = new HttpClient();
                //var idcategoria = e.SelectedItem as categorias;
               // string cadenasql = $"http://paraisoreal19.somee.com/api/categoriass/Getcategorias/{0}",{ idcategoria.id};
               // var response = await clients.GetStringAsync($"http://paraisoreal19.somee.com/api/categoriass/Getcategorias/1");
               // var vercategorias = JsonConvert.DeserializeObject<categorias>(response);



                await App.Current.MainPage.Navigation.PushAsync(new VerDetalleP { BindingContext = e.SelectedItem });
            }
        }
    }
}