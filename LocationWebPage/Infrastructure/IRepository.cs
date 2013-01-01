using LocationWebPage.Models;

namespace LocationWebPage.Infrastructure
{
    public interface IRepository
    {
        void SaveUser(User user);
        User GetUser(string userName);
        User GetUser(string userName, string password);
    }
}