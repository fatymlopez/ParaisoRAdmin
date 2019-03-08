using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class VerUsuarioVM
    {
        public VerUsuarioVM()
        {
            BorrarUsuCommand = new Command(BorrarUsu);
            EditarUsuCommand = new Command(EditarUsu);
        }

        public async void EditarUsu()
        {
          
        }

        public async void BorrarUsu()
        {
            
        }

        

        #region comandos
        public Command BorrarUsuCommand { get; set; }
        public Command EditarUsuCommand { get; set; }
        #endregion
    }
}
