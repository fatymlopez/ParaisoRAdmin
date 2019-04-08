using Newtonsoft.Json;
using ParaisoRealA.Model;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDesayuno : ContentPage
    {
        public NDesayuno()
        {
            InitializeComponent();
            BindingContext = this;
            // getubicacion();

          
           
        }

        



        //public async void getubicacion()
        //{
        //    var client = new HttpClient();
        //    string URL = string.Format(Constantes.Base +"/api/ubicacions/Getubicacion");
        //    var miArreglo = await client.GetStringAsync(URL);
        //    Itemubicacion = JsonConvert.DeserializeObject<List<ubicacion>>(miArreglo);

        //    Debug.WriteLine(Itemubicacion);
        //}

        private void PedidosUbicacion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }




        #region proppiedades
        //private List<ubicacion> _itemubicacion;

        //public List<ubicacion> Itemubicacion
        //{
        //    get { return _itemubicacion; }
        //    set { _itemubicacion = value; OnPropertyChanged(); }
        //}

        //private int _idss;

        //public int idss
        //{
        //    get { return _idss; }
        //    set { _idss = value; OnPropertyChanged(); }
        //}

        //private ubicacion _selectubicacion;

        //public ubicacion selectubucacion
        //{
        //    get { return _selectubicacion; }
        //    set
        //    {
        //        _selectubicacion = value;
        //        var name = _selectubicacion.nomubicacion;
        //        idss = _selectubicacion.id;

        //App.Current.MainPage.DisplayAlert("Ubicacion Seleccionada", name, "Ok");
        //if (idss == 1)
        //{

        //        var clientorder = new HttpClient();
        //        string URL = string.Format(Constantes.Base + "/api/ordens/Getorden");
        //        var miArreglo1 =  clientorder.GetStringAsync(URL);
        //        var verorden = JsonConvert.DeserializeObject<List<orden>>(miArreglo1);
        //        var nuevalista = verorden.Where(a => a.idubicacion == 1);
        //        PedidosUbicacion.ItemsSource = nuevalista;



        //}


        //    }
        //}
        #endregion

        public async void Univocd_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/ordens/Getorden");
            var miArreglo = await client.GetStringAsync(URL);
            var verproductos = JsonConvert.DeserializeObject<List<orden>>(miArreglo);
            var nuevalista = verproductos.Where(a => a.idubicacion == 1 );
            PedidosUbicacion.ItemsSource = nuevalista;
        }

        public async void Munivo_Clicked(object sender, EventArgs e)
        {

        }

        public async void Uma_Clicked(object sender, EventArgs e)
        {

        }
    }
}