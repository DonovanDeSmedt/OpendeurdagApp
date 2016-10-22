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
    public sealed partial class cars : Page
    {
        private List<Car> autos;
        public cars()
        {
            this.InitializeComponent();
            autos = CarManager.GetCars();
        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cars = (Car)e.ClickedItem;
            ResultTextBlock.Text = "You Selected--->>" + cars.Category + "--->>Model_ " + cars.Model;
        }
    }
}
