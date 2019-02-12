using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ParaisoRealA.View;

namespace ParaisoRealA.ViewModel
{
    public class DetalleMenusVM
    {
        public DetalleMenusVM()
        {
         
            EditarCommand = new Command(MetodoEditar);
        }

        public async void MetodoEditar()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Actulizar());
        }

        private void MetodoEliminar()
        {
            
        }

        #region Comandos
       
        public Command EditarCommand { get; set; }
        #endregion
    }
}
