using Newtonsoft.Json;
using ParaisoRealA.Model;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerDetalleP : ContentPage
    {
        public VerDetalleP()
        {
            InitializeComponent();

            BindingContext = this;
            //getpickercat();
            //getpickerest();
            var vBinding = this;
            selectcategory = new categorias();
            string unodostres = idcategoria.ToString();
            //idp = Convert.ToInt32(idca.Text);
            ide = Convert.ToInt32(idest.Text);

        }

        public VerDetalleP(productos productosrr = null)
            :this()
        {
            ProductoRecibido = productosrr;
            idp = ProductoRecibido.idcategoria;
            ide = ProductoRecibido.idestado;
        }
        protected override void OnAppearing()
        {
            getpickercat();
            getpickerest();

            base.OnAppearing();
        }

        public async void getpickerest()
        {
            var client1 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/estadoss/Getestados");
            var miArreglostado = await client1.GetStringAsync(URL);
            Itemestado = JsonConvert.DeserializeObject<List<estados>>(miArreglostado);
            estadoselec.ItemsSource = Itemestado;
        }

        public async void getpickercat()
        {
            var client2 = new HttpClient();
            string URL = string.Format(Constantes.Base + "/api/categoriass/Getcategorias");
            var miArreglocategorias = await client2.GetStringAsync(URL);
            Itemcategory = JsonConvert.DeserializeObject<List<categorias>>(miArreglocategorias);
            categorys.ItemsSource = Itemcategory;
            
        }

        public async void Btneditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                productos actualizarp = new productos
                {
                    id = Convert.ToInt32(idprodu.Text),
                    idcategoria = this.idp,
                    nomproducto = nomp.Text,
                    descripcion = desc.Text,
                    precio = Convert.ToDecimal(pricep.Text),
                    idestado = this.ide

                };
            

            var json = JsonConvert.SerializeObject(actualizarp);
            var conn = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient cli = new HttpClient();
            var result = await cli.PutAsync(string.Concat(Constantes.Base + "/api/productoss/Putproductos/", idprodu.Text), conn);

            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Mensaje", "Datos actualizados con exito", "OK");
                await App.Current.MainPage.Navigation.PopAsync();


            }
            }
            catch (Exception ee)
            {
                var a = ee.Message;
            }
        }

        private int ValorCategoria()
        {
            int idcategoriat = 0;
            if (selectcategory == null)
            {
                selectcategory = new categorias();
                idcategoriat = ProductoRecibido.idcategoria;

            }
            else
                idcategoriat = selectcategory.id;


            return idcategoriat;
        }

        public async void Bteliminar_Clicked(object sender, EventArgs e)
        {
                var answer = await DisplayAlert("Mensaje", "Desea Eliminar el Producto", "Si", "No");
                if (answer == true)
                {
                    HttpClient borrarcli = new HttpClient();
                    var resultb = await borrarcli.DeleteAsync(string.Concat(Constantes.Base + "/api/productoss/Deleteproductos/", idprodu.Text));
                    if (resultb.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Mensaje", "Producto Eliminado con Exito", "OK");
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Mensaje", "Operacion Cancelada", "Ok");
                    

                }

            }
        
        #region propiedades
        private List<categorias> _itemcategory = new List<categorias>();
        public List<categorias> Itemcategory
        {
            get { return _itemcategory; }
            set { _itemcategory = value; OnPropertyChanged(); }
        }

        private int _idp;
        public int idp
        {
            get { return _idp; }
            set { _idp = value; OnPropertyChanged(); }
        }

        private categorias _selectcategory;
        public categorias selectcategory
        {
            get { return _selectcategory; }
            set
            {
                _selectcategory = value;
                var names = _selectcategory.nomcategoria;
                idp = _selectcategory.id;
                //App.Current.MainPage.DisplayAlert("Mensaje", "Categoria Actualizada", "Ok");

            }
        }

        private List<estados> _itemestado = new List<estados>();
        public List<estados> Itemestado
        {
            get { return _itemestado; }
            set { _itemestado = value; OnPropertyChanged(); }
        }

        private int _ide;
        public int ide
        {
            get { return _ide; }
            set { _ide = value; OnPropertyChanged(); }
        }

        private estados _selectestado;
        public estados selectestado
        {
            get { return _selectestado; }
            set
            {
                _selectestado = value;
                var names2 = _selectestado.nomestado;
                ide = _selectestado.id;
                //App.Current.MainPage.DisplayAlert("Mensaje", "Estado Actualizado con exito", "OK");

            }
        }
        #endregion

        #region eventos

        private void Categorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectcategory = categorys.SelectedItem as categorias;
            this.idp = selectcategory.id;
        }

        private void Estadoselec_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectestado = estadoselec.SelectedItem as estados;
            this.ide = selectestado.id;
        }

        private int _idCategoria;

        public int idcategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; OnPropertyChanged(); }
        }


        private productos _ProductoRecibido;

        public productos ProductoRecibido
        {
            get { return _ProductoRecibido; }
            set { _ProductoRecibido = value; OnPropertyChanged(); }
        }


        #endregion
    }


}

