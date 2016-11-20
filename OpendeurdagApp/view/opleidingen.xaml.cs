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

            var parentContainer = this.listView.ItemContainerGenerator.ContainerFromItem(sender);
            var textblock = FindControl<TextBlock>(parentContainer, "textblockRichting");
            textblock.Visibility = Visibility.Collapsed;


        }

        private List<Control> AllChildren(DependencyObject parent)
        {
            var _List = new List<Control>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control)
                {
                    _List.Add(_Child as Control);
                }
                _List.AddRange(AllChildren(_Child));
            }
            return _List;
        }


        private T FindControl<T>(DependencyObject parentContainer, string controlName)
        {
            var childControls = AllChildren(parentContainer);
            var control = childControls.OfType<Control>().Where(x => x.Name.Equals(controlName)).Cast<T>().First();
            return control;
        }

        

        //private void ListViewItemBedrijfsmanagement_OnTapped(object sender, TappedRoutedEventArgs e)
        //{
        //    if (textBlockBedrijfsmanagsement.Visibility == Visibility.Visible)
        //    {
        //        textBlockBedrijfsmanagsement.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        textBlockBedrijfsmanagsement.Visibility = Visibility.Visible;
        //    }

        //}

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