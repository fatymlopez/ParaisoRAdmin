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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
        }

        public async void Btnsesion_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usu.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe Ingresar un usuario", "Ok");

                usu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Password.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe Ingresar una contraseña", "Ok");
                Password.Focus();
                return;
            }

            //obtener campos...

            indicator.IsRunning = true;
            btnsesion.IsEnabled = false;
            var client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/usuapps/Getusuapp");
            var miArreglo = await client.GetStringAsync(URL);

            var vercliente = JsonConvert.DeserializeObject<List<usuapp>>(miArreglo);
            foreach (var item in vercliente)
            {
                if (item.usuario == usu.Text && item.passusu == Password.Text)
                {
                    Constantes.usuario = item.usuario;
                    Constantes.contraseña = item.passusu;
                    Constantes.nombreu = item.nombre;
                    Constantes.idusuario = item.id;
                    break;
                }
            }

            indicator.IsRunning = false;
            btnsesion.IsEnabled = true;

            if (Constantes.idusuario == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Datos no validos", "Ok");
                Password.Text = string.Empty;
                Password.Focus();
                return;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Bienvenido" + Constantes.nombreu, "ok");
                await Application.Current.MainPage.Navigation.PushAsync(new MasterMenu());

            }
        }
    }
}