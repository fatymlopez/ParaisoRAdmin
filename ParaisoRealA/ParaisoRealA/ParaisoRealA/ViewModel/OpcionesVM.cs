using System;
using System.Collections.Generic;
using System.Text;
using ParaisoRealA.Model;

namespace ParaisoRealA.ViewModel
{
    public class OpcionesVM: OpcionesModel
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
                //new OpcionesVM(typeof(View.Reportevta), "Ver Reporte Ventas", "reportapp"),
                new OpcionesVM(typeof(View.Login), "Cerrar Sesion", "salir"),



            };
        }

        #region propiedades
        public static IList<OpcionesVM> All { private set; get; }
        #endregion
    }
}
