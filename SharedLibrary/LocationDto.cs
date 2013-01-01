using System;

namespace SharedLibrary
{
    public class LocationDto
    {
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Response { get; set; }

    }
}