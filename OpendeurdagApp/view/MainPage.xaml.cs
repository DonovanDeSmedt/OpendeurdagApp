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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpendeurdagApp.View
{
    public sealed partial class MainPage : UserControl
    {
        private MainPageViewModel mainvm;

        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainvm = DataContext as MainPageViewModel;
            GridView gridView = (GridView)sender;
            StackPanel q = (StackPanel) gridView.SelectedItem;
            switch (q.Tag.ToString())
            {
                case "richting":
                    {
                        mainvm.OpleidingenCommand.Execute(this);
                        break;
                    }
                case "campus":
                    {
                        mainvm.CampussenCommand.Execute(this);
                        break;
                    }
                case "newsfeed":
                    {
                        mainvm.NewsFeedCommand.Execute(this);
                        break;
                    }
                case "admin":
                    {
                        mainvm.AdminCommand.Execute(this);
                        break;
                    }
            }
        }
    }
}
