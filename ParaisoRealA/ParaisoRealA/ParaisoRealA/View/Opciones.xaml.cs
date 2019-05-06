using ParaisoRealA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParaisoRealA.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Opciones : ContentPage
	{
		public Opciones ()
		{
			InitializeComponent ();
		}

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                ViewModel.OpcionesVM pageData = args.SelectedItem as ViewModel.OpcionesVM;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                await Navigation.PushAsync(page);


            }
        }

       
            public  void Cerrarsesion_Clicked(object sender, EventArgs e)
            {
                
          

            }

       
    }
}