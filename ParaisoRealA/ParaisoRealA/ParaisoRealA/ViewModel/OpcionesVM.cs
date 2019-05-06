using System;
using System.Collections.Generic;
using System.Text;
using ParaisoRealA.Model;
using ParaisoRealA.View;
using Xamarin.Forms;

namespace ParaisoRealA.ViewModel
{
    public class OpcionesVM : OpcionesModel
    {
        public OpcionesVM(Type type, string titulo, string icono)
        {
            Type = type;
            Titulo = titulo;
            Icono = icono;


        }


        static OpcionesVM()
        {
            All = new List<OpcionesVM>
            {

                new OpcionesVM(typeof(View.IngresarProducto), "Ingresar Producto", "ingresoproduct"),
                new OpcionesVM(typeof(View.VerProductos), "Ver Productos Ingresados", "searchfood"),
                new OpcionesVM(typeof(View.IngresarUsuario), "Ingresar Usuario", "user"),
                new OpcionesVM(typeof(View.VerUsuario), "Ver Usuarios Registrados", "searchuserapp"),
                new OpcionesVM(typeof(View.VerClientesR), "Ver Clientes Registrados", "searchuser"),
                new OpcionesVM(typeof(View.Login), "Cerrar Sesión", "salir"),

            };




        }

         


        #region propiedades
        public static IList<OpcionesVM> All { set; get; }
     
        #endregion
    }
}
