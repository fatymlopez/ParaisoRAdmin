using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealA.Model.Modeldb
{
    public class reservacion
    {
        public int id { get; set; }
        public int idubicacion { get; set; }
        public int idcliente { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
