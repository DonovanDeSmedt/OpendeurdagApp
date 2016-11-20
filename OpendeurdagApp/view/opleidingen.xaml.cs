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
using OpendeurdagApp.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Opleidingen : Page
    {

        private OpleidingenViewModel ovm;
        public Opleidingen()
        {

            this.InitializeComponent();
            ovm=DataContext as OpleidingenViewModel;
        }

        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
        }



        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (!ovm.IsLoaded)
                {
                    await ovm.Loadrichtingen();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}