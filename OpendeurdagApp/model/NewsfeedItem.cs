using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Model
{
    public class NewsfeedItem : INotifyPropertyChanged
    {
        private string titel;

        public string Title
        {
            get
            {
                return titel;
            }
            set
            {
                titel = value;
                RaisePropertyChanged();
            }
        }

        private string inhoud;

        public string Inhoud
        {
            get { return inhoud; }
            set
            {
                inhoud = value;
                RaisePropertyChanged();
            }
        }

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set
            {
                datum = value;
                RaisePropertyChanged();
            }
        }

        private string tag;

        public string Tag
        {
            get { return tag; }
            set
            {
                tag = value;
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
