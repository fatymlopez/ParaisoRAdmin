using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealA.Model.Modeldb
{
    public class detallereservacion
    {
        public int idreservacion { get; set; }
        public int idproducto { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal? subtotal { get; set; }
        public productos productos { get; set; }
        public reservacion reservacion { get; set; }


    }
}

