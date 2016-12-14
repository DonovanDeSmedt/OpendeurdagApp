using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        private Richting selectedRichting;
        private Campus selectedCampus;
        private Gebouw selectedGebouw;
        public Admin()
        {
            this.InitializeComponent();
            
        }

        private void OnCampusSelected(object sender, SelectionChangedEventArgs e)
        {
            selectedCampus = (Campus) e.AddedItems[0];
            vm = DataContext as AdminViewModel;
            vm.SelectedCampus = selectedCampus;
            vm.Richtingen = new ObservableCollection<Richting>(vm.SelectedCampus.Richtingen);
        }
        private void OnRichtingSelected(object sender, SelectionChangedEventArgs e)
        {
            selectedRichting = (Richting)e.AddedItems[0];
            vm = DataContext as AdminViewModel;
            vm.SelectedRichting = selectedRichting;
        }
        private void OnGebouwSelected(object sender, SelectionChangedEventArgs e)
        {
            selectedGebouw = (Gebouw)e.AddedItems[0];
            vm = DataContext as AdminViewModel;
            vm.SelectedGebouw = selectedGebouw;
        }

        private void OnCampusAdded(object sender, TappedRoutedEventArgs e)
        {
            vm = DataContext as AdminViewModel;
            vm.AddNewCampus(txfCampusNaam.Text, txfCampusLocatie.Text);
        }
        private void OnRichtingAdded(object sender, TappedRoutedEventArgs e)
        {
            vm = DataContext as AdminViewModel;
            vm.AddNewRichting(txfRichtingNaam.Text, txfRichtingOmschrijving.Text);
        }
        private void OnGebouwAdded(object sender, TappedRoutedEventArgs e)
        {
            vm = DataContext as AdminViewModel;
            vm.AddNewGebouw(txfGebouwNaam.Text);
        }
        private async void OnCampusDeleted(object sender, TappedRoutedEventArgs e)
        {
            vm = DataContext as AdminViewModel;
            var result = await showMessageDialog("Campus verwijderen",
               "Bent u zeker dat u de campus " + selectedCampus.Naam + " wilt verwijderen?");

            if (result)
            {
                vm.DeleteObject("campus", selectedCampus.CampusId.ToString());
            }
        }
        private async void OnRichtingDeleted(object sender, TappedRoutedEventArgs e)
        {
            vm = DataContext as AdminViewModel;
            bool result = await showMessageDialog("Richting verwijderen",
                "Bent u zeker dat u de richting " + selectedRichting.Naam + " wilt verwijderen?");
            if (result)
            {
                vm.DeleteObject("richtings", selectedRichting.RichtingId.ToString());
            }
            
        }
        
        private async void OnGebouwdDeleted(object sender, TappedRoutedEventArgs e)
        {
            vm = DataContext as AdminViewModel;
            bool result = await showMessageDialog("Gebouw verwijderen",
               "Bent u zeker dat u de gebouw " + selectedGebouw.Naam + " wilt verwijderen?");
            if (result)
            {
                vm.DeleteObject("gebouws", selectedGebouw.GebouwId.ToString());
            }
        }
        private async Task<bool> showMessageDialog(string title, string content)
        {

            var dialog = new MessageDialog(content, title);

            dialog.Commands.Add(new UICommand("Ja") { Id = 0 });
            dialog.Commands.Add(new UICommand("Neen") { Id = 1 });

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();
            //result.Completed += (info, status) => { Debug.WriteLine(info + " " + status); };
            return result.Id.ToString() == "0"; //GetResults().Id.ToString() == "0";
        }


        private void WijzigingOpslaan(object sender, TappedRoutedEventArgs e)
        {
            bool isCampusChanged = false;
            bool isRichtingChanged = false;
            bool isGebouwChanged = false;

            string campusText = txfCampusNaam.Text;
            string campusLocatie = txfCampusLocatie.Text;
            string richtingText = txfRichtingNaam.Text;
            string richtingOmschrijving = txfRichtingOmschrijving.Text;

            string gebouwText = txfGebouwNaam.Text;

            //Eventuele wijzigingen aan object doorvoeren
            if (selectedCampus != null)
            {
                if (campusText != selectedCampus.Naam)
                {
                    selectedCampus.Naam = campusText;
                    isCampusChanged = true;
                }
                if (campusLocatie != selectedCampus.Adres)
                {
                    selectedCampus.Adres = campusLocatie;
                    isCampusChanged = true;
                }
            }
            if (selectedRichting != null)
            {
                if (richtingText != selectedRichting.Naam)
                {
                    selectedRichting.Naam = richtingText;
                    isRichtingChanged = true;
                }
                if (richtingOmschrijving != selectedRichting.Omschrijving)
                {
                    selectedRichting.Omschrijving = richtingOmschrijving;
                    isRichtingChanged = true;
                }
            }
            if (selectedGebouw != null)
            {
                if (gebouwText != selectedGebouw.Naam)
                {
                    selectedGebouw.Naam = gebouwText;
                    isGebouwChanged = true;
                }
            }
            

            //Updates doorvoeren
            if (isCampusChanged)
            {
                vm.UpdateObject(selectedCampus, "campus", selectedCampus.CampusId.ToString());
            }
            if (isRichtingChanged)
            {
                vm.UpdateObject(selectedRichting, "richtings", selectedRichting.RichtingId.ToString());
            }
            if (isGebouwChanged)
            {
                vm.UpdateObject(selectedGebouw, "gebouws", selectedGebouw.GebouwId.ToString());
            }
        }
    }
}
