﻿using System;
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
using OpendeurdagApp.Utils;

namespace OpendeurdagApp.ViewModel
{
    public class CampussenViewModel: ViewModelBase
    {
        private MainPageViewModel _mainvm;
        private readonly string url = "http://localhost:51420/api/";
        public RelayCommand CampusDetailCommand { get; set; }
        private ObservableCollection<Campus> campussen;
        public ObservableCollection<Campus> Campussen
        {
            get { return campussen; }
            set { campussen = value; RaisePropertyChanged(); }
        }
        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; RaisePropertyChanged(); }
        }

        private Campus campus;
        public Campus Campus
        {
            get { return campus; }
            set { campus = value; RaisePropertyChanged(); }
        }

        public bool IsDataLoaded { get; set; }
        public CampussenViewModel(MainPageViewModel mainvm)
        {
            _mainvm = mainvm;
            //Eerst loadingscherm (dummydata) tonen terwijl de data wordt opgehaald
            Campussen = new ObservableCollection<Campus>(CampusRepository.GetCampussen());
            Campus = Campussen[0];
            CampusDetailCommand = new RelayCommand(campus => ShowDetailsCampus(campus));
            IsLoading = true;
            GetCampussen();
        }

        private void ShowDetailsCampus(Object o)
        {
            Campus campus = (Campus) o;
            _mainvm.CampusDetailCommand.Execute(campus);
        }


        private async Task GetCampussen()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url+"campus");
            Campussen = JsonConvert.DeserializeObject<ObservableCollection<Campus>>(jsonString);
            IsDataLoaded = true;
            IsLoading = false;
        }

        public async Task LoadCampussen()
        {
            await GetCampussen();
        }
        

    }
}
