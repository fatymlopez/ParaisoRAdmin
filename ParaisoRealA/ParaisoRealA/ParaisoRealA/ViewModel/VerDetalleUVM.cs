using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class VerDetalleUVM 
    { 
        public VerDetalleUVM()
        {
            BorrarUsuCommand = new Command(BorrarUsuApp);
        }

        public async void BorrarUsuApp()
        {
            HttpClient client = new HttpClient();
           
            
            var result = await client.DeleteAsync(String.Concat("http://paraisoreal19.somee.com/api/usuapps/Deleteusuapp/", id));


            if (result.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Hey", "Eliminastes el registro", "ok");
            }
        }

        #region propiedades
        public int id { get; set; }
        
        #endregion
        #region  comandos
        public Command BorrarUsuCommand { get; set; }
       
        #endregion
    }
}
