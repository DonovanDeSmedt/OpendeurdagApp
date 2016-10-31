using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpendeurdagApp.Model;
using OpendeurdagApp.Model.DAL;

namespace OpendeurdagApp.ViewModel
{
    class CampussenViewModel: ViewModelBase
    {
        public ObservableCollection<Campus> Campussen { get; set; }
        public CampussenViewModel()
        {
            Campussen = new ObservableCollection<Campus>(CampusRepository.GetCampussen());
        }
    }
}
