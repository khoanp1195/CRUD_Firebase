using CRUDFIREBASE.Model;
using CRUDFIREBASE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDFIREBASE.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailIOTPage : ContentPage
    {
        DBFirebase service;
        public DetailIOTPage( DataIOT dataIOT)
        {
            InitializeComponent();
            BindingContext = dataIOT;
            service = new DBFirebase();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await service.DeleteIOT(day.Text,humidity.Text, temperature.Text, status.Text,time.Text);
            await Navigation.PushAsync(new IOTPage());

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await service.UpdateIOT(day.Text, humidity.Text, temperature.Text, status.Text, time.Text);
            await Navigation.PushAsync(new IOTPage());

        }
    }
}