using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace OpendeurdagApp.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public DataTemplate Template { get; set; }

        public ViewModelBase()
        {
            Template = GetTemplate();
        }

        private DataTemplate GetTemplate()
        {
            string name = GetType().Name;
            return (DataTemplate)App.Current.Resources[name];
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
