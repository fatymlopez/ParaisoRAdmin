﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealA.Model.Modeldb
{
    public class orden
    {
        public int id { get; set; }
        public int idubicacion { get; set; }
        public int idreservacion { get; set; }
        public DateTime fecha { get; set; }
        public int?  estado { get; set; }

        public cliente cliente { get; set; }
        public List<detallereservacion> detallereservacion { get; set; }
       

        public reservacion reservacion { get; set; }

       
       

    }
}
