using Newtonsoft.Json;
using OpendeurdagApp.Model;
using OpendeurdagApp.Model.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpendeurdagApp.Utils;

namespace OpendeurdagApp.ViewModel
{
    public class CampusDetailViewModel: ViewModelBase
    {
        private readonly string url = "http://localhost:51420/api/";
        
        private Campus _campus;
        private MainPageViewModel _mainvm;
        public RelayCommand RichtingDetailCommand { get; set; }

        public Campus Campus { get { return _campus;}  set { _campus = value; RaisePropertyChanged(); } }
        public bool IsDataLoaded { get; set; }
        public CampusDetailViewModel(MainPageViewModel mainvm, Campus campus)
        {
            _mainvm = mainvm;
            Campus = campus;
            RichtingDetailCommand = new RelayCommand(richting => ShowRichtingDetails(richting));
        }

        private void ShowRichtingDetails(Object o)
        {
            Richting richting = (Richting) o;
            _mainvm.OpleidingenCommand.Execute(richting);
        }
    }
}
