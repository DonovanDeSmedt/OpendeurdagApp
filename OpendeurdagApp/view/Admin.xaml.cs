using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class Admin : Page
    {
        private AdminViewModel vm;
        public Admin()
        {
            this.InitializeComponent();
        }

        private void OnCampusSelected(object sender, SelectionChangedEventArgs e)
        {
            Campus campus = (Campus) e.AddedItems[0];
            vm = DataContext as AdminViewModel;
            vm.SelectedCampus = campus;
            vm.Richtingen = new ObservableCollection<Richting>(vm.SelectedCampus.Richtingen);
        }
        private void OnRichtingSelected(object sender, SelectionChangedEventArgs e)
        {
            Richting richting = (Richting)e.AddedItems[0];
            vm = DataContext as AdminViewModel;
            vm.SelectedRichting = richting;
        }
        private void OnGebouwSelected(object sender, SelectionChangedEventArgs e)
        {
            Gebouw gebouw = (Gebouw)e.AddedItems[0];
            vm = DataContext as AdminViewModel;
            vm.SelectedGebouw = gebouw;
        }

        private void OnCampusAdded(object sender, TappedRoutedEventArgs e)
        {
           vm.AddNewCampus(txfCampusNaam.Text, txfCampusLocatie.Text);
        }
        private void OnRichtingAdded(object sender, TappedRoutedEventArgs e)
        {
            vm.AddNewRichting(txfRichtingNaam.Text, txfRichtingOmschrijving.Text);
        }
        private void OnGebouwAdded(object sender, TappedRoutedEventArgs e)
        {
            vm.AddNewGebouw(txfGebouwNaam.Text);
        }
    }
}
