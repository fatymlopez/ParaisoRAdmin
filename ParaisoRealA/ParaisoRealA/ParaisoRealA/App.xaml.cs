using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ParaisoRealA.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ParaisoRealA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

         
          //  MainPage = new NavigationPage(new Login());
            var navigationPage = new NavigationPage(new Login());
            navigationPage.BarBackgroundColor = Color.Black;

            navigationPage.BarTextColor = Color.Black;
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
