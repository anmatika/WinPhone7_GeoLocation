using System;
using System.Collections.Generic;
using AutoMapper;
using SharedLibrary;

namespace LocationWebPage.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ForeName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection <LocationDto> Locations { get; set; }

    }
}