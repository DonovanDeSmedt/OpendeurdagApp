using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace OpendeurdagApp.View
{
    public sealed partial class LocatieControl : UserControl
    {
        public LocatieControl()
        {
            this.InitializeComponent();
            ShowPOI();
        }
        private void ShowPOI()
        {
            BasicGeoposition snPosition = new BasicGeoposition()
            {
                Latitude = 51.030460,
                Longitude = 3.703510
            };
            // Specify a known location.
            Geopoint snPoint = new Geopoint(snPosition);
            // Create a MapIcon.
            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.Location = snPoint;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = "HoGent campus Schoonmeersen";
            mapIcon1.ZIndex = 0;


            // Add the MapIcon to the map.
            MyMap.MapElements.Add(mapIcon1);
            MyMap.Center = snPoint;
            MyMap.ZoomLevel = 10;


        }
    }
}
