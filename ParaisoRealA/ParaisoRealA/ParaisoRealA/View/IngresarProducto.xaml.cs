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
	public partial class IngresarProducto : ContentPage
	{
		public IngresarProducto ()
		{
			InitializeComponent ();
           // GetPickercategory();
		}

        //esta malo modificar
        public async Task GetPickercategory( int id)
        {
             
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://paraisoreal19.somee.com/api/categoriass/Getcategorias/5");
            var vercategory = JsonConvert.DeserializeObject<List<categorias>>(response);
            category.ItemsSource = vercategory;
        }

        public async void Btnguardar_Clicked(object sender, EventArgs e)
        {
           
            productos newproduct = new productos()
            {
                
              nomproducto = nomproductocomm,
              descripcion = descripcioncomm,
              existencia = existenciascomm,
              precio = preciocomm,
              idcategoria = Convert.ToInt32(idcategoriacomm.Text)
            };

            var json = JsonConvert.SerializeObject(newproduct);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/productoss/Postproductos", content);

            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                
                await App.Current.MainPage.DisplayAlert("Genial!", "El producto se ha guardado con exito", "Ok");


            }

        }

        #region propiedades
        public string nomproductocomm { get; set; }
        public string descripcioncomm { get; set; }
        public int existenciascomm { get; set; }
        public decimal preciocomm { get; set; }
      
        #endregion
    }
}