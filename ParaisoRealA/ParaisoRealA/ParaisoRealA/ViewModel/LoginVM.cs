using ParaisoRealA.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
   public class LoginVM
    {
        public LoginVM()
        {
            OpcionesCommand = new Command(Ingresar);
        }

        public  void Ingresar()
        {
            App.Current.MainPage.Navigation.PushAsync(new MasterMenu());
        }

        #region
        public Command OpcionesCommand { get; set; }
        #endregion
    }

}
