using CRUDFIREBASE.Model;
using CRUDFIREBASE.ViewModel;
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
    public partial class IOTPage : ContentPage
    {
        public IOTPage()
        {
            InitializeComponent();
            BindingContext = new IOTViewModel();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddIOT());
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var dataiot = e.Item as DataIOT;
            if (dataiot == null) return;

            await Navigation.PushAsync(new DetailIOTPage(dataiot));
            lstIOT.SelectedItem = null;
                
        }


    }
}