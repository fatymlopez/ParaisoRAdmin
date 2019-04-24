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
	public partial class VerDetalleU : ContentPage
	{
		public VerDetalleU ()
		{
			InitializeComponent ();
        }

        public async void Actusu_Clicked(object sender, EventArgs e)
        {
            usuapp actualizarusu = new usuapp
            {
                id = Convert.ToInt32(idusu.Text),
                nombre = usuappnom.Text,
                usuario = usuarioapp.Text,
                emailusu = correous.Text,
                passusu = paswords.Text,
            };

            var json = JsonConvert.SerializeObject(actualizarusu);
            var connusu = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient cli = new HttpClient();
            var result = await cli.PutAsync(string.Concat(Constantes.Base + "/api/usuapps/Putusuapp/", idusu.Text), connusu);

            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Mensaje", "Datos actualizados con exito", "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }

        }

        public async void EliminarUsu_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Mensaje", "Desea Eliminar el Usuario", "Si", "No");

            if (answer == true)
            {
                HttpClient borrarusu = new HttpClient();
                var resultu = await borrarusu.DeleteAsync(string.Concat(Constantes.Base + "/api/usuapps/Deleteusuapp/", idusu.Text));
                if (resultu.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Usuario Eliminado con Exito", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Operacion Cancelada", "Ok");

            }
        }
    }
}