using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealA.View;

namespace ParaisoRealA.ViewModel
{
    public class VerDetalleVM
    {
        public VerDetalleVM()
        {
            EditarPCommand = new Command(EditarProduct);
        }

        public async void EditarProduct()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ActualizarP());
        }

        #region Comandos
        public Command EditarPCommand { get; set; }
        #endregion
    }
}
