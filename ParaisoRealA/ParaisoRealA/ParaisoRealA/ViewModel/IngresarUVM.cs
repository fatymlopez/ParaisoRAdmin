using Newtonsoft.Json;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class IngresarUVM
    {
        public IngresarUVM()
        {
            AgregarUsuCommand = new Command(AgregarUsuApp);
        }

        public async void AgregarUsuApp()
        {
            usuapp newuser = new usuapp()
            {
                nombre =  nomproperty,
                usuario = usuproperty,
                emailusu = emailproperty,
                passusu = passproperty
            };

            var json = JsonConvert.SerializeObject(newuser);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/usuapps/Postusuapp", content);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");

            }

        }

        #region propiedades
        public string nomproperty { get; set;}
        public string usuproperty { get; set;}
        public string emailproperty { get; set;}
        public string passproperty { get; set;}
        #endregion

        #region comandos
        public Command AgregarUsuCommand { get; set; }
        #endregion
    }

}
