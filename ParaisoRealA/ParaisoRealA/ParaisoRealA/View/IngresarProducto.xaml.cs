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
        public IngresarProducto()
        {
            InitializeComponent();
            GetPickercategory();
        }


        public async void GetPickercategory()
        {

            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://paraisoreal19.somee.com/api/categoriass/Getcategorias");
            var vercategory = JsonConvert.DeserializeObject<List<categorias>>(response);
            category.ItemsSource = vercategory;
        }
    }
     
}