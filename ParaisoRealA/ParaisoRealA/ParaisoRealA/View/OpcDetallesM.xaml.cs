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
	public partial class OpcDetallesM : ContentPage
	{
		public OpcDetallesM ()
		{
			InitializeComponent ();
		}

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                ViewModel.OpcDetalleVM pageData = args.SelectedItem as ViewModel.OpcDetalleVM;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                await Navigation.PushAsync(page);


            }
        }
    }
}