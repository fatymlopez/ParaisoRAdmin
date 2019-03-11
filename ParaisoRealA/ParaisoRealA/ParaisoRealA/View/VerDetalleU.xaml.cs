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

            BorrarUsuCommand = new Command(BorrarMierda);

           

        }

        #region
        public Command BorrarUsuCommand { get; set; }
        #endregion

        #region propiedades
        public string id { get; set; }
        #endregion
        public async void BorrarMierda()
        {
            HttpClient client = new HttpClient();

            var result = await client.DeleteAsync(String.Concat("http://paraisoreal19.somee.com/api/usuapps/Deleteusuapp/", id));


            if (result.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Hey", "Eliminastes el registro", "ok");
            }
        }
    }
}