using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Model
{
    public class Campus:INotifyPropertyChanged
    {
        private int campusId;

        public int CampusId
        {
            get { return campusId; }
            set
            {
                campusId = value;
                RaisePropertyChanged();
            }
        }
        private string adres;

        public string Adres
        {
            get { return adres; }
            set
            {
                adres = value;
                RaisePropertyChanged();
            }
        }

        private string naam;
       public string Naam
        {
            get { return naam; }
            set
            {
                naam = value;
                RaisePropertyChanged();
            }
        }

        private List<Richting> richtingen;

        public List<Richting> Richtingen
        {
            get
            {
                return richtingen;
            }
            set
            {
                richtingen = value;
                RaisePropertyChanged();
            }
        }
        private List<Gebouw> gebouwen;

        public List<Gebouw> Gebouwen
        {
            get
            {
                return gebouwen;
            }
            set
            {
                gebouwen = value;
                RaisePropertyChanged();
            }
        }

        private string foto;
        public string Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
