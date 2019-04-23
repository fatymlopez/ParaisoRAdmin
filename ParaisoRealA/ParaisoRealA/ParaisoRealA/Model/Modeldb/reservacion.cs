using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealA.Model.Modeldb
{
    public class reservacion
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public decimal total { get; set; }
        public int? estado { get; set; }
        public int? idubicacion { get; set; }
        public cliente cliente { get; set; }

        //public static IList<detallereservacion> detallereservacion { get; set; }

    }
}
