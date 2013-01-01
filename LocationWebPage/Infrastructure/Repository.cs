using System;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using EFEntities;
using LocationWebPage.Models;

namespace LocationWebPage.Infrastructure
{
    public class Repository : IRepository
    {
        public void SaveUser(User user)
        {
            Mapper.CreateMap<User, Users>();
            var users = Mapper.Map<User, Users>(user);

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];

                // Ten iterations.
                for (int i = 0; i < 10; i++)
                {
                    // Fill buffer.
                    rng.GetBytes(data);

                    // Convert to int 32.
                    int value = BitConverter.ToInt32(data, 0);
                    Console.WriteLine(value);
                }
            }
            

            using (var entities = new anmatiEntities())
            {
                if (user.Id != 0)
                {
                    entities.Users.Attach(users);
                }
                else
                {
                    entities.Users.Add(users);
                }

                entities.SaveChanges();
            }
        }

        public User GetUser(string userName)
        {
            User user = null;
            using (var entities = new anmatiEntities())
            {
                var users = entities.Users.FirstOrDefault(u => u.UserName == userName);
                if (users != null)
                {
                    Mapper.CreateMap<Users, User>();
                    user = Mapper.Map<Users, User>(users);
                }
            }

            return user;
        }

        public User GetUser(string userName, string password)
        {
            User user = null;
            using (var entities = new anmatiEntities())
            {
                var users = entities.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
                if (users != null)
                {
                    Mapper.CreateMap<Users, User>();
                    user = Mapper.Map<Users, User>(users);
                }
            }

            return user;
        }
    }
}