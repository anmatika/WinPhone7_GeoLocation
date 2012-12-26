using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Reactive;

namespace Location
{
    public partial class MainPage : PhoneApplicationPage
    {

        GeoCoordinateWatcher gcw; // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (gcw != null)
                gcw.Stop(); 
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (gcw == null)
                gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

            gcw.Start();

            map1.Center = new GeoCoordinate(gcw.Position.Location.Latitude, gcw.Position.Location.Longitude);
            map1.ZoomLevel = 5;
            map1.ZoomBarVisibility = Visibility.Visible;
            gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(myCoordinateWatcher_PositionChanged);
        }

        private void myCoordinateWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            ShowGeoLocation();
        }

        private void ShowGeoLocation()
        {
            textBlock1.Text = "Latitude: " + gcw.Position.Location.Latitude;
            textBlock1.Text += "\nLongitude" + gcw.Position.Location.Longitude;

            map1.Center = new GeoCoordinate(gcw.Position.Location.Latitude, gcw.Position.Location.Longitude);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ShowGeoLocation();
        }

        
    }
}