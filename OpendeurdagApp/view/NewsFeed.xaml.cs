using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
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
using OpendeurdagApp.Model.DAL;
using OpendeurdagApp.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsFeed : Page
    {
        private NewsFeedViewModel vm;
        public NewsFeed()
        {
            this.InitializeComponent();
        }
        private async void BtnVerstuurOnTapped(object sender, TappedRoutedEventArgs e)
        {

            string achternaam = achternaamBox.Text;
            string voornaam = voornaamBox.Text;
            string email = emailBox.Text;
            Richting r = (Richting)comboBoxRichtingen.SelectedValue;
            Debug.WriteLine(r);

            bool gelukt = FormulierInschrijvingRepo.VerstuurMailNieuweInschrijving(achternaam, voornaam,email, r);
            if (gelukt)
            {
                MessageDialog dialog = new MessageDialog("We hebben je gegevens goed ontvangen!", "Ingeschreven");
                await dialog.ShowAsync();
                achternaamBox.Text = "";
                voornaamBox.Text = "";
                emailBox.Text = "";
                comboBoxRichtingen.SelectedIndex = -1;
            }
            
        }

        private async void Login(object sender, TappedRoutedEventArgs e)
        {
            bool result = await UserRepository.login(loginEmail.Text, loginWw.Password);
            btnLogin.Content = result ? "afmelden": "login";
            vm = DataContext as NewsFeedViewModel;
            vm.setIsAdmin(result);
        }
    }
}
