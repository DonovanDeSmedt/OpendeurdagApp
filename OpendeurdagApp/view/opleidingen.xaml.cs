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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Opleidingen : Page
    {
        public Opleidingen()
        {
            this.InitializeComponent();
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
