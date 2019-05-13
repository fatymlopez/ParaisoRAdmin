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
	public partial class VerUsuario : ContentPage
	{
		public VerUsuario ()
		{
			InitializeComponent ();
            GetListUsuario();
		}

        
        public async void GetListUsuario()
        {
            indicatorusuc.IsRunning = true;
           
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(Constantes.Base + "/api/usuapps/Getusuapp");
                var verusuario = JsonConvert.DeserializeObject<List<usuapp>>(response);
                UsuarioAppListView.ItemsSource = verusuario;

                UsuarioAppListView.IsEnabled = true;

            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Mesanje", "No hay conexion a internet", "Ok");
                UsuarioAppListView.IsEnabled = true;
                indicatorusuc.IsRunning = false;
                return;
            }

            indicatorusuc.IsRunning = false;

        }

        private async void UsuarioAppListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            if (e.SelectedItem != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new VerDetalleU { BindingContext = e.SelectedItem });
            }

        }

        public async void Searchusuarios_TextChanged(object sender, TextChangedEventArgs e)
        {
            HttpClient clientsearch = new HttpClient();
            var response = await clientsearch.GetStringAsync(Constantes.Base + "/api/usuapps/Getusuapp");
            var verusuarios = JsonConvert.DeserializeObject<List<usuapp>>(response);
            var newuserList = verusuarios.Where(i => i.nombre.Contains(e.NewTextValue));

            UsuarioAppListView.ItemsSource = newuserList;

            UsuarioAppListView.BeginRefresh();

            UsuarioAppListView.EndRefresh();

        }
    }
}