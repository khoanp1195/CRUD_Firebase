using CRUDFIREBASE.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDFIREBASE.Services
{
    class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://esp8266project-8ea11-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<DataIOT> getDataIOT()
        {
            var iotData = client
                .Child("FirebaseIOT")
                .AsObservable<DataIOT>()
                .AsObservableCollection();
            return iotData;

        }
        public async Task AddIOT(string day, string humidity, string temperature, string status, string time)
        {
            DataIOT iot = new DataIOT() { Day = day, Humidity = humidity, Temperature = temperature, Status = status, Time = time };
            await client
             .Child("FirebaseIOT")
             .PostAsync(iot);
                
        }
        public async Task UpdateIOT (string day, string humidity, string temperature, string status, string time)
        {

            var toUpdateIOT = (await client
                .Child("FirebaseIOT")
                 .OnceAsync<DataIOT>()).FirstOrDefault
               (a => a.Object.Day == day);

            DataIOT iot = new DataIOT() { Day = day, Humidity = humidity, Temperature = temperature, Status = status, Time = time };
            await client
                  .Child("FirebaseIOT")
                  .Child(toUpdateIOT.Key)
                  .PutAsync(iot);

        }
        public async Task DeleteIOT(string day, string humidity, string temperature, string status, string time)
        {
            var toDeleteIOT = (await client
              .Child("FirebaseIOT")
              .OnceAsync<DataIOT>()).FirstOrDefault
              (a => a.Object.Day == day || a.Object.Humidity == humidity || a.Object.Temperature == temperature || a.Object.Status == status || a.Object.Time == time);
            await client.Child("FirebaseIOT").Child(toDeleteIOT.Key).DeleteAsync();
                
        }
    }
}
