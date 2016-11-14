using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Model
{
    public class Gebouw: INotifyPropertyChanged
    {
        private int gebouwId;

        public int GebouwId
        {
            get { return gebouwId; }
            set
            {
                gebouwId = value;
                RaisePropertyChanged();
            }
        }
        private string gebouwNaam;

        public string Naam
        {
            get { return gebouwNaam; }
            set
            {
                gebouwNaam = value;
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
