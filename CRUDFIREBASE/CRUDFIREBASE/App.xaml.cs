using CRUDFIREBASE.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDFIREBASE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage ( new IOTPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
