using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
   public class ActualizarVM
    {
        public ActualizarVM()
        {
            EliminarCommand = new Command(MetodoEliminar);
            ActualizarCommand = new Command(MetodoActulizar);
        }

        private void MetodoActulizar()
        {
            
        }

        private void MetodoEliminar()
        {
           
        }


        #region Comandos
        public Command EliminarCommand { get; set; }
        public Command ActualizarCommand { get; set; }        
        #endregion 
    }
}
