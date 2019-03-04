using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using ParaisoRealA.Model.Modeldb;
using ParaisoRealA.View;

namespace ParaisoRealA.ViewModel
{
    public class VerClientRVM
    {
        public VerClientRVM()
        {
            //GetListCliente();
        }

       /* public async void GetListCliente()
        {

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://paraisoreal19.somee.com/api/clientes/Getcliente");
            var Cliente = JsonConvert.DeserializeObject<List<cliente>>(response);

            










        }*/


        

    }


}
