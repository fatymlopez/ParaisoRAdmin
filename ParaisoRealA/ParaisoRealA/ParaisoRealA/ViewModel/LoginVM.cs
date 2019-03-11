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
            OpcionesCommand = new Command(notificaciones);

        }

        public async void notificaciones()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MasterMenu());
        }

        #region comandos
        public Command OpcionesCommand { get; set; }
        #endregion
    }


}
