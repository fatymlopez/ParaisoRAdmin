using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealA.Model.Modeldb
{
    public class categorias
    {
        public categorias()
        {
            productos = new HashSet<productos>();
        }
        public int id { get; set; }
        public string nomcategoria { get; set; }

        public virtual ICollection<productos> productos { get; set; }

    }
    
}
