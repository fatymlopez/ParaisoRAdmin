using ParaisoRealA.Model;
using ParaisoRealA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenu : MasterDetailPage
    {
        public MasterMenu()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MasterBehavior = MasterBehavior.Popover;
            IsPresented = false;

            //Device.BeginInvokeOnMainThread(typeof(Login) () =>
            //{
            //    var response = await DisplayAlert("Mensaje", "¿Desea cerrar sesion?", "Si", "No");
            //    if (response == true)
            //    {
            //        Autenticar();
            //        await Navigation.PopModalAsync();
                  
            //    }
            //    else
            //    {
            //        await App.Current.MainPage.DisplayAlert("Mensaje", "Operacion Cancelada", "Ok");
            //    }


            //});
        }

        //public void Autenticar()
        //{
        //    Constantes.usuario = "";
        //    Constantes.contraseña = "";
        //}



    }   
}
           
