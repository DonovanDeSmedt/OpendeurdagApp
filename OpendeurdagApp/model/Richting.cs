using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Model
{
    public class Richting : INotifyPropertyChanged
    {
        private int richtingId;

        public int RichtingId
        {
            get { return richtingId; }
            set
            {
                richtingId = value;
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

        private string omschrijving;

        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; RaisePropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}