using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpendeurdagApp.Utils;

namespace OpendeurdagApp.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            OpleidingenCommand = new RelayCommand(_ => ShowOpleidingen());
            CampussenCommand = new RelayCommand(_ => ShowCampussen());
        }
        private ViewModelBase currentData;

        public ViewModelBase CurrentData
        {
            get { return currentData; }
            set { currentData = value; RaisePropertyChanged(); }
        }

        public RelayCommand OpleidingenCommand { get; set; }
        public RelayCommand CampussenCommand { get; set; }

        private void ShowOpleidingen()
        {
            CurrentData = new OpleidingenViewModel();
            Debug.WriteLine("Command opleiding werd uitgevoerd!");
        }

        private void ShowCampussen()
        {
            CurrentData = new CampussenViewModel();
            Debug.WriteLine("Command campus werd uitgevoerd!");
        }

    }
}
