using CRUDFIREBASE.Model;
using CRUDFIREBASE.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CRUDFIREBASE.ViewModel
{
    public class IOTViewModel : BaseViewModel
    {
        public string Day { get; set; }
        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }

        private DBFirebase services;
        public Command AddIOTCommand { get; }

        private ObservableCollection<DataIOT> _dataIOTs = new ObservableCollection<DataIOT>();
        public ObservableCollection<DataIOT> dataIOTs
        {
            get { return _dataIOTs; }
            set
            {
                _dataIOTs = value;
                OnPropertyChanged();
            }

        }
        public IOTViewModel()
        {
            services = new DBFirebase();
            dataIOTs = services.getDataIOT();
            AddIOTCommand = new Command(async () => await addIOTAsync(Day, Humidity, Temperature, Status, Time));
        }

        private async Task addIOTAsync(string Day, string Humidity, string Temperature, string Status, string Time) 
        {
            await services.AddIOT(Day, Humidity, Temperature, Status, Time);
        }

    
    }
}
