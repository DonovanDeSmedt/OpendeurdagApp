using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpendeurdagApp.Model;
using OpendeurdagApp.Model.DAL;

namespace OpendeurdagApp.ViewModel
{
    class CampussenViewModel: ViewModelBase
    {
        private readonly string url = "http://localhost:19962/api/";

        private ObservableCollection<Campus> campussen;
        public ObservableCollection<Campus> Campussen
        {
            get { return campussen; }
            set { campussen = value; RaisePropertyChanged(); }
        }

        public bool IsDataLoaded { get; set; }
        public CampussenViewModel()
        {
            //Eerst loadingscherm (dummydata) tonen terwijl de data wordt opgehaald
            Campussen = new ObservableCollection<Campus>(CampusRepository.GetCampussen());
            GetCampussen();
        }

        private async Task GetCampussen()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url+"campus");
            Campussen = JsonConvert.DeserializeObject<ObservableCollection<Campus>>(jsonString);
            Debug.WriteLine(Campussen[0].Naam);
            IsDataLoaded = true;
        }

        public async Task LoadCampussen()
        {
            await GetCampussen();
        }
        

    }
}
