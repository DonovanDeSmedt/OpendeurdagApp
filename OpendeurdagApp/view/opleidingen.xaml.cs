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
    public sealed partial class opleidingen : Page
    {
        private List<Opleiding> opleidingenList=new List<Opleiding>(); 
        public opleidingen()
        {
            this.InitializeComponent();
            Opleiding informatica=new Opleiding("Toegepaste Informatica", "De IT'er van vandaag is veel meer dan alleen maar een technische expert. Hij of zij moet tegelijkertijd een ondernemende, communicatieve en klantgerichte teamspeler zijn. IT is namelijk geëvolueerd van een zuiver technisch verhaal naar 'IT as a service and support tool'. De moderne IT'er is dan ook vooral een ITmanager: iemand die in staat is de strategie van een bedrijf te vertalen naar ICT-oplossingen.");
            Opleiding bedrijfsmanagement=new Opleiding("Bedrijfsmanagement","Bedrijfsshit enzo, super leerrijk, jwz");
            opleidingenList.Add(informatica);
            opleidingenList.Add(bedrijfsmanagement);

            this.DataContext = informatica;

        }

        private void ListViewItemInformatica_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (textBlockInformatica.Visibility == Visibility.Visible)
            {
                textBlockInformatica.Visibility = Visibility.Collapsed;
            }
            else
            textBlockInformatica.Visibility = Visibility.Visible;
        }

        private void ListViewItemBedrijfsmanagement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (textBlockBedrijfsmanagsement.Visibility == Visibility.Visible)
            {
                textBlockBedrijfsmanagsement.Visibility = Visibility.Collapsed;
            }
            else
            {
                textBlockBedrijfsmanagsement.Visibility = Visibility.Visible;
            }

        }
    }
}
