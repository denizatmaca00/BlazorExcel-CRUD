
using BlazorOne.Models;
using BlazorOne.DbOjects;

namespace BlazorOne.Services
{
    public interface IUserServices
    {
        List<User> GetUsers();
    }
}
