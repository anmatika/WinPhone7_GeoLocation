using System;
using System.Device.Location;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using RestSharp;

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
            {
                _gcw.Stop();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_gcw == null)
            {
                _gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            }

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
                            Template = Resources["pinMyLoc"] as ControlTemplate,
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

        private void SendLocationClick(object sender, RoutedEventArgs e)
        {
            SendAsync();
        }

        private void SendAsync()
        {
            var client = new RestClient("http://localhost:50590/");

            //var request = new RestRequest("{id}", Method.POST);
            var request = new RestRequest("api/phone/phonerequest", Method.POST);


          //  request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
             
            // easily add HTTP Headers
           // request.AddHeader("header", "value");
            request.RootElement = "Call";
            request.AddParameter("Call", new Call());
            request.AddHeader("Content-type", "application/json");
            var rest = client.ExecuteAsyncPost<Call>(request, OnCallback, "POST");
            
            // abort the request on demand
            //asyncHandle.Abort();
        }

        private void OnCallback(IRestResponse<Call> restResponse, RestRequestAsyncHandle handle)
        {
            var call = restResponse.Data;
          
        }

        public void CreateUser()
        {
            RestRequest request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json, Resource = "api/phone" };
            var client = new RestClient("http://localhost:50590/Phone/CreateUser");

            CUser user = new CUser
            {
                Username = "Foo2",
                Password = "BarBaz2"
            };

            request.AddParameter("Username", user.Username);
            request.AddParameter("Password", user.Password);

            client.PostAsync<int>(request, (response, handler) =>
            {
                switch (response.Data)
                {
                    case 0:
                        //Username is taken

                        break;
                    case 1:
                        //Success
                        break;
                    case 2:
                        break;
                }

            });
        }
    }

    public class CUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Call
    {
        public string Sid { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string CallSegmentSid { get; set; }
        public string AccountSid { get; set; }
        public string Called { get; set; }
        public string Caller { get; set; }
        public string PhoneNumberSid { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public int Flags { get; set; }
    }
}