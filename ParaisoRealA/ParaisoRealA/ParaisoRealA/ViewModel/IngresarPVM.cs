using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParaisoRealA.Model;
using ParaisoRealA.Model.Modeldb;
using ParaisoRealA.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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


        private List<estados> _itemestado;

        public List<estados> Itemestado
        {
            get { return _itemestado; }
            set { _itemestado = value; RaisePropertyChanged(); }
        }

        public IngresarPVM()
        {
            AgregarProductoCommand = new Command(AgregarProducto);

            GetPickercategory();

            GetPickerEstado();

        }

        public async void GetPickerEstado()
        {
            var client1 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/estadoss/Getestados");
            var miArreglostado = await client1.GetStringAsync(URL);
            Itemestado = JsonConvert.DeserializeObject<List<estados>>(miArreglostado);
            Debug.WriteLine(Itemestado);
        }

        public async void GetPickercategory()
        {
            var client = new HttpClient();
            string URL = string.Format(Constantes.Base +"/api/categoriass/Getcategorias");
            var miArreglo = await client.GetStringAsync(URL);
            Itemcategory = JsonConvert.DeserializeObject<List<categorias>>(miArreglo);
            Debug.WriteLine(Itemcategory);
        }


        public async void AgregarProducto()
        {
            if (this.ids == 0 || this.nomproductocomm == null || this.descripcioncomm == null || this.idstatus == 0 || this.preciocomm== 0)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje", "Debes ingresar todos los datos ", "Ok");
            }
            else
            {
                productos newproduct = new productos()
                {
                    idcategoria = this.ids,
                    nomproducto = this.nomproductocomm,
                    descripcion = this.descripcioncomm,
                    idestado = this.idstatus,
                    precio = this.preciocomm

                };
                var json = JsonConvert.SerializeObject(newproduct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync(Constantes.Base + "/api/productoss/Postproductos", content);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    await App.Current.MainPage.DisplayAlert("Genial!", " Tu registro se ha realizado con exito", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                    


                }
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
                App.Current.MainPage.DisplayAlert("Nombre de la categoria", name + " el id es: " +""+ ids, "OK");
            }

        }


        private int _idstatus;

        public int idstatus
        {
            get { return _idstatus; }
            set { _idstatus = value;  RaisePropertyChanged(); }
        }

        private estados _selectestado;

        public estados selectestado
        {
            get { return _selectestado; }
            set {
                _selectestado = value;
                var namestatus = _selectestado.nomestado;
                idstatus = _selectestado.id;
                App.Current.MainPage.DisplayAlert("Estado", namestatus + "El id es" + "" + idstatus, "Ok");
            }
        }

        #endregion
        #region Comandos
        public Command AgregarProductoCommand { get; set; }
        #endregion
    }
}
