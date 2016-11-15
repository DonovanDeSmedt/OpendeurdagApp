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
using OpendeurdagApp.View;

namespace OpendeurdagApp.ViewModel
{
    class OpleidingenViewModel:ViewModelBase
    {

        private readonly string url = "http://localhost:19962/api/";

        public bool IsLoaded { get; set; }

        private ObservableCollection<Richting> richtingen;

        public ObservableCollection<Richting> Richtingen
        {
            get { return richtingen; }
            set { richtingen = value; RaisePropertyChanged(); }
        }

        public OpleidingenViewModel()
        {

            GetOpleidingen();
        }


        private async Task GetOpleidingen()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url + "richtings");
            Richtingen = JsonConvert.DeserializeObject<ObservableCollection<Richting>>(jsonString);
            Debug.WriteLine(Richtingen[0].Naam);
            IsLoaded = true;
        }

        public async Task Loadrichtingen()
        {
            await GetOpleidingen();
        }


    }
}
