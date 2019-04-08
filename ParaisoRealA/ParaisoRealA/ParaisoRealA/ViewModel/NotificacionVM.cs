using ParaisoRealA.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class NotificacionVM
    {
        public NotificacionVM()
        {
            
                Tapcommand = new Command(Notificaciondesayuno);
                Tapcommand2 = new Command(Notificacionalmuerzos);
                Tapcommand3 = new Command(Notificacionantojitos);
            

        }
        public async void Notificaciondesayuno(object obj)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NDesayuno());
        }
        public async void Notificacionalmuerzos(object obj)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NAlmuerzo());
        }

        public async void Notificacionantojitos(object obj)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NAntojitos());
        }

        #region comandos
        public Command Tapcommand { get; set; }
        public Command Tapcommand2 { get; set; }
        public Command Tapcommand3 { get; set; }
        #endregion

    }


}
