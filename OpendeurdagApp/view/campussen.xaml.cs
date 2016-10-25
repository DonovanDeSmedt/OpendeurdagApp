using System;
using System.Collections.Generic;
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
using OpendeurdagApp.model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class campussen : Page
    {
        private static List<Richting> listRichtingen = new List<Richting>{new Richting() {Naam = "Toegepaste informatica"}, new Richting() { Naam = "Bedrijfsmanagement" } };

        private static Campus schoonmeersen = new Campus()
        {
            Adres = "Valentin Vaerweglaan 9000 Gent",
            Naam = "Campus Schoonmeersen",
            Richtingen = listRichtingen,
            Foto = "ms-appx:///Assets/schoonmeersen.jpg"
        };
        private static Campus ledeganck = new Campus()
        {
            Adres = "Centrum 9000 Gent",
            Naam = "Campus Ledeganck",
            Richtingen = listRichtingen
        };
        private List<Campus> listCampussen = new List<Campus> { schoonmeersen, ledeganck };
        

        public campussen()
        {
            this.InitializeComponent();
            this.DataContext = schoonmeersen;
        }
        private void Richting_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            //Go to view opleidingen en de listview van de opleiding openklikken
        }
    }
    
}
