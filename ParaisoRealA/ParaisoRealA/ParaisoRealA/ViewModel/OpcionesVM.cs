﻿using System;
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
             
                new OpcionesVM(typeof(View.IngresarProducto), "Ingresar Producto", ""),
                new OpcionesVM(typeof(View.VerProductos), "Ver Productos Ingresados", ""),
                new OpcionesVM(typeof(View.IngresarUsuario), "Ingresar Usuario", ""),
                new OpcionesVM(typeof(View.VerUsuario), "Ver Usuarios Registrados", ""),
                new OpcionesVM(typeof(View.VerClientesR), "Ver Clientes Registrados", ""),
                

            };
        }

        #region propiedades
        public static IList<OpcionesVM> All { private set; get; }
        #endregion
    }
}
