using Newtonsoft.Json;
using ParaisoRealA.Model;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class IngresarUVM : ViewModelBase, INotifyPropertyChanged
    {
        public IngresarUVM()
        {
            AgregarUsuCommand = new Command(AgregarUsuApp);
        }

        public async void AgregarUsuApp()
        {
            if (this.nomproperty == null || this.usuproperty == null || this.emailproperty == null || this.passproperty == null)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Debe ingresar todos los datos", "Ok");
            }
            else
            {
                try
                {
                    IsBusy = true;
                    usuapp newuser = new usuapp()
                {
                    nombre = nomproperty,
                    usuario = usuproperty,
                    emailusu = emailproperty,
                    passusu = passproperty
                };

                var json = JsonConvert.SerializeObject(newuser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync(Constantes.Base + "/api/usuapps/Postusuapp", content);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }

                }
                catch (Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Mensaje", "No hay conexion a internet", "Ok");

                    return;
                }
                finally
                {
                    IsBusy = false;
                }
            }

        }

        #region propiedades
        private string _nomproperty;
        public string nomproperty
        {
            get { return _nomproperty; }
            set { _nomproperty = value; RaisePropertyChanged(); }
        }

        private string _usuproperty;
        public string usuproperty
        {
            get { return _usuproperty; }
            set { _usuproperty = value; RaisePropertyChanged(); }
        }

        private string _emailproperty;
        public string emailproperty
        {
            get { return _emailproperty; }
            set { _emailproperty = value; RaisePropertyChanged(); }
        }

        private string _passproperty;

        public string passproperty
        {
            get { return _passproperty; }
            set { _passproperty = value; RaisePropertyChanged(); }
        }

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region comandos
        public Command AgregarUsuCommand { get; set; }
        #endregion
    }

}
