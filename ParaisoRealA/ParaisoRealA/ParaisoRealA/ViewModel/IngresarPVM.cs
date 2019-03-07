using Newtonsoft.Json;
using ParaisoRealA.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class IngresarPVM 
    {
        public IngresarPVM()
        {
           
            AgregarProductoCommand = new Command(AgregarProducto);
        }

        public async void AgregarProducto()
        {
           
        }












        #region Comandos
        public Command AgregarProductoCommand { get; set; }
        #endregion
    }
}
