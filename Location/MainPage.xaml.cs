using System.Device.Location;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;

namespace Location
{
    public partial class MainPage : PhoneApplicationPage
    {
        private GeoCoordinateWatcher _gcw; 

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (_gcw != null)
                _gcw.Stop();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_gcw == null)
                _gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

            _gcw.Start();

            Map1.Center = new GeoCoordinate(_gcw.Position.Location.Latitude, _gcw.Position.Location.Longitude);
            Map1.ZoomLevel = 5;
            Map1.ZoomBarVisibility = Visibility.Visible;
            _gcw.PositionChanged += MyCoordinateWatcherPositionChanged;
        }

        private void MyCoordinateWatcherPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            ShowGeoLocation();
        }

        private void ShowGeoLocation()
        {
            TextBlock1.Text = "Latitude: " + _gcw.Position.Location.Latitude;
            TextBlock1.Text += "\nLongitude" + _gcw.Position.Location.Longitude;

            Map1.Center = new GeoCoordinate(_gcw.Position.Location.Latitude, _gcw.Position.Location.Longitude);
            var p = new Pushpin
                        {
                            Template = this.Resources["pinMyLoc"] as ControlTemplate,
                            Location = _gcw.Position.Location
                        };

            mapControl.Items.Clear();
            mapControl.Items.Add(p);
            Map1.SetView(_gcw.Position.Location, 17.0);
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            ShowGeoLocation();
        }
    }
}