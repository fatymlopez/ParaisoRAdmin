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

        //para que se vea la contraseña
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Passwordss.IsPassword = Passwordss.IsPassword ? false : true;
        }

        //validacion 
        public async void Btnsesion_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usu.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe Ingresar un usuario", "Ok");

                usu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(Passwordss.Text))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe Ingresar una contraseña", "Ok");
                Passwordss.Focus();
                return;
            }

            //obtener campos...

            indicator.IsRunning = true;
            try
            {
                btnsesion.IsEnabled = false;
                var client = new HttpClient();
                string URL = string.Format( Constantes.Base + "/api/usuapps/Getusuapp");
                var miArreglo = await client.GetStringAsync(URL);

                var vercliente = JsonConvert.DeserializeObject<List<usuapp>>(miArreglo);
                foreach (var item in vercliente)
                {
                    if (item.usuario == usu.Text && item.passusu == Passwordss.Text)
                    {
                        Constantes.usuario = item.usuario;
                        Constantes.contraseña = item.passusu;
                        Constantes.nombreu = item.nombre;
                        Constantes.idusuario = item.id;
                        break;
                    }
                }

                btnsesion.IsEnabled = true;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay Conexion", "Ok");
                btnsesion.IsEnabled = true;
                indicator.IsRunning = false;
                return;

            }

           
            indicator.IsRunning = false;
         

            if (Constantes.idusuario == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Datos no validos", "Ok");
                Passwordss.Text = string.Empty;
                Passwordss.Focus();
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