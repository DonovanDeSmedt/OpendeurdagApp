using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OpendeurdagApp.Model;
using OpendeurdagApp.Model.DAL;
using OpendeurdagApp.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Campussen : Page
    {
        private CampussenViewModel cvm;
        private ObservableCollection<Richting> Richtingen;
        public ObservableCollection<Gebouw> gebouwen;
        public Campussen()
        {
            this.InitializeComponent();
            Richtingen = new ObservableCollection<Richting>(CampusRepository.GetCampussen()[0].Richtingen);
            gebouwen = new ObservableCollection<Gebouw>();

        }
        private void OnChangeCampus(object sender, ItemClickEventArgs e)
        {
            //Go to view opleidingen en de listview van de opleiding openklikken
            Campus campus = (Campus) e.ClickedItem;
            cvm = DataContext as CampussenViewModel;
            cvm.Campus = campus;
            

        }
 
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (!cvm.IsDataLoaded)
                {
                    await cvm.LoadCampussen();
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
    
}
