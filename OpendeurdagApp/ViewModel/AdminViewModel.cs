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
using OpendeurdagApp.Utils;

namespace OpendeurdagApp.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        private readonly string url = "http://localhost:51420/api/";
        public RelayCommand AdminCommand { get; set; }
        private ObservableCollection<Campus> campussen;
        public string PostError { get; set; }
        public bool IsLoadingCampus { get; set; }
        public bool IsLoadingRichting { get; set; }
        private Campus campus;

        public Campus SelectedCampus
        {
            get
            {
                return campus;
                
            }
            set
            {
                campus = value;
                RaisePropertyChanged();
            }
        }
        private Richting richting;

        public Richting SelectedRichting
        {
            get
            {
                return richting;

            }
            set
            {
                richting = value;
                RaisePropertyChanged();
            }
        }
        private Gebouw gebouw;

        public Gebouw SelectedGebouw
        {
            get
            {
                return gebouw;

            }
            set
            {
                gebouw = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoading { get; set; }
        public ObservableCollection<Campus> Campussen
        {
            get { return campussen; }
            set
            {
                campussen = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<Richting> richtingen;
        public ObservableCollection<Richting> Richtingen
        {
            get { return richtingen; }
            set { richtingen = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<Campus> gebouwen;
        public ObservableCollection<Campus> Gebouwen
        {
            get { return gebouwen; }
            set { gebouwen = value; RaisePropertyChanged(); }
        }

        public AdminViewModel()
        {
            IsLoading = true;
            IsLoadingRichting = true;
            IsLoadingCampus = true;
            GetCampussen();
            GetRichtingen();

            //AdminCommand = new RelayCommand(_ => ShowAdminPage());
        }

        public void AddNewCampus(string naam, string locatie)
        {
            Campus newCampus = new Campus
            {
                Naam = naam,
                Adres = locatie,
                Foto = "ms-appx:///Assets/building.png"
            };
            Campussen.Add(newCampus);
            RaisePropertyChanged();
            postNewCampus(campus);
        }

        private async Task postNewCampus(Campus campus)
        {
            HttpClient client = new HttpClient();
            String jsonCampus = JsonConvert.SerializeObject(campus);
            HttpResponseMessage response = await client.PostAsync(new Uri(url + "campus"), new StringContent(jsonCampus));
            if (!response.IsSuccessStatusCode)
            {
                PostError = response.ReasonPhrase;
            }
        }
        public void AddNewRichting(string naam, string omschrijving)
        {
            if (SelectedCampus != null)
            {                      
                Richting newRichting = new Richting
                {
                    Naam = naam,
                    Omschrijving = omschrijving
                };
                Campussen.First(c => c.Naam == SelectedCampus.Naam).Richtingen.Add(newRichting);
                SelectedCampus.Richtingen.Add(newRichting);
                RaisePropertyChanged();
            }

        }

        public void AddNewGebouw(string naam)
        {
            if (SelectedCampus != null)
            {
                Gebouw newGebouw = new Gebouw
                {
                    Naam = naam
                };
                Campussen.First(c => c.Naam == SelectedCampus.Naam).Gebouwen.Add(newGebouw);
                SelectedCampus.Gebouwen.Add(newGebouw);
                RaisePropertyChanged();
            }
            
        }

        private async Task GetCampussen()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url + "campus");
            Campussen = JsonConvert.DeserializeObject<ObservableCollection<Campus>>(jsonString);
            IsLoadingCampus = false;
            IsLoading = IsLoadingCampus && IsLoadingRichting;
        }
        private async Task GetRichtingen()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url + "richtings");
            Richtingen = JsonConvert.DeserializeObject<ObservableCollection<Richting>>(jsonString);
            IsLoadingRichting = false;
            IsLoading = IsLoadingCampus && IsLoadingRichting;
        }

    }
}