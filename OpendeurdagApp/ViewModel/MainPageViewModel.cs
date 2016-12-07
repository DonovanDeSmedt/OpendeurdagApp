using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpendeurdagApp.Model;
using OpendeurdagApp.Utils;

namespace OpendeurdagApp.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            OpleidingenCommand = new RelayCommand(opleiding => ShowOpleidingen(opleiding));
            CampussenCommand = new RelayCommand(_ => ShowCampussen());
            CampusDetailCommand = new RelayCommand(campus => ShowDetailCampus(campus));
            NewsFeedCommand = new RelayCommand(_ => ShowNewsFeed());
            AdminCommand = new RelayCommand(_ => ShowAdminPage());
        }
        private ViewModelBase currentData;

        public ViewModelBase CurrentData
        {
            get { return currentData; }
            set { currentData = value; RaisePropertyChanged(); }
        }

        public RelayCommand OpleidingenCommand { get; set; }
        public RelayCommand CampussenCommand { get; set; }
        public RelayCommand CampusDetailCommand { get; set; }
        public RelayCommand NewsFeedCommand { get; set; }
        public RelayCommand AdminCommand { get; set; }

        private void ShowOpleidingen(Object o)
        {
            Richting richting = (Richting) o;
            Debug.WriteLine(richting); 
            CurrentData = new OpleidingenViewModel();
            Debug.WriteLine("Command opleiding werd uitgevoerd!");
        }

        private void ShowAdminPage()
        {
            CurrentData = new AdminViewModel();
        }

        private void ShowCampussen()
        {
            CurrentData = new CampussenViewModel(this);
            Debug.WriteLine("Command campus werd uitgevoerd!");
        }

        private void ShowDetailCampus(Object o)
        {
            Campus campus = (Campus) o;
            CurrentData = new CampusDetailViewModel(this, campus);
            Debug.WriteLine("Command campusDetail werd uitgevoerd!");
        }

        private void ShowNewsFeed()
        {
            CurrentData = new NewsFeedViewModel(this);
            Debug.WriteLine("NewsFeed command werd uitgevoerd");
        }
    }

}
