using System;
using System.Collections.Generic;
using System.Text;

namespace ParaisoRealA.Model.Modeldb
{
    public class productos
    {
        
        public int id { get; set; }
        public int idcategoria { get; set; }
        public string nomproducto { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int idestado { get; set; }
        public categorias categorias { get; set; }
        public estados estados { get; set; }

        
    }
}
