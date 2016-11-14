using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OpendeurdagApp.Model;
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
        public Campus campus = new Campus() {Adres = "TEST", Naam = "TESTNAAm"};

        public Campussen()
        {
            this.InitializeComponent();
            cvm = DataContext as CampussenViewModel;
        }
        private void Richting_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            //Go to view opleidingen en de listview van de opleiding openklikken
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
