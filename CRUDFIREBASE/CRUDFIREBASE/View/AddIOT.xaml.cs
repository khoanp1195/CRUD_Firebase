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
    public partial class AddIOT : ContentPage
    {
        public AddIOT()
        {
            InitializeComponent();
            BindingContext = new IOTViewModel();
        }
    }
}