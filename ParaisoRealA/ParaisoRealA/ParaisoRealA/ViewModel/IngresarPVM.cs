using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class IngresarPVM : INotifyPropertyChanged
    {

        private List<categorias> _itemcategory;

        public List<categorias> Itemcategory { get { return _itemcategory; } set { _itemcategory = value; RaisePropertyChanged(); } }

        private void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                if (!string.IsNullOrEmpty(propertyname))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }

        public IngresarPVM()
        {
            AgregarProductoCommand = new Command(AgregarProducto);

            GetPickercategory();

        }

        public async void GetPickercategory()
        {
            var client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/categoriass/Getcategorias");
            var miArreglo = await client.GetStringAsync(URL);
            Itemcategory = JsonConvert.DeserializeObject<List<categorias>>(miArreglo);
            Debug.WriteLine(Itemcategory);
        }


        public async void AgregarProducto()
        {
            productos newproduct = new productos()
            {
                idcategoria = this.ids,
                nomproducto = this.nomproductocomm,
                descripcion = this.descripcioncomm,
                existencia = this.existenciascomm,
                precio = this.preciocomm

            };
            var json = JsonConvert.SerializeObject(newproduct);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync("http://paraisoreal19.somee.com/api/productoss/Postproductos", content);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");

            }


        }
        #region propiedades
        private int _ids;
        public int ids
        {
            get { return _ids; }
            set { _ids = value; RaisePropertyChanged(); }
        }

        private string _nomproductocomm;
        public string nomproductocomm
        {
            get { return _nomproductocomm; }
            set { _nomproductocomm = value; RaisePropertyChanged(); }
        }

        private string _descripcioncomm;
        public string descripcioncomm
        {
            get { return _descripcioncomm; }
            set { _descripcioncomm = value; RaisePropertyChanged(); }
        }

        private int _existenciascomm;
        public int existenciascomm
        {
            get { return _existenciascomm; }
            set { _existenciascomm = value; RaisePropertyChanged(); }
        }

        private  decimal _preciocomm;
        public  decimal preciocomm
        {
            get { return _preciocomm; }
            set { _preciocomm = value; RaisePropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private categorias _selectcategory;
        public categorias selectcategory
        {

            get { return _selectcategory; }
            set
            {
                _selectcategory = value;
                var name = _selectcategory.nomcategoria;
                ids = _selectcategory.id;
                App.Current.MainPage.DisplayAlert("Nombre de la categoria", name + " el id es: " + ids, "oki");
            }

        }

        #endregion
        #region Comandos
        public Command AgregarProductoCommand { get; set; }
        #endregion
    }
}
