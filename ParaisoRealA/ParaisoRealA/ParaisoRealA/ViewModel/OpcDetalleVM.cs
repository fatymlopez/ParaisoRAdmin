using System;
using System.Collections.Generic;
using System.Text;
using ParaisoRealA.Model;


namespace ParaisoRealA.ViewModel
{
     public class OpcDetalleVM :  OpcDetalleModel
    {
        public OpcDetalleVM(Type type, string titulo, string icono)
        {
            Type = type;
            Titulo = titulo;
            Icono = icono;
        }

        static OpcDetalleVM()
        {
            All = new List<OpcDetalleVM>
            {
                
              //ojo esto se va a cambiar..... 
                new OpcDetalleVM(typeof(View.DetalleMenus), "Desayunos", ""),
                new OpcDetalleVM(typeof(View.DetalleMenus), "Almuerzos", ""),
                new OpcDetalleVM(typeof(View.DetalleMenus), "Combos", ""),
                new OpcDetalleVM(typeof(View.DetalleMenus), "Bebidas Frias", ""),
                new OpcDetalleVM(typeof(View.DetalleMenus), "Bebidas Calientes", ""),

            };
        }

        #region propiedades
        public static IList<OpcDetalleVM> All { private set; get; }
        #endregion

    }
}
