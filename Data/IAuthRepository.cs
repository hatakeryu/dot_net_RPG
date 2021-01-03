using System.Threading.Tasks; 
using dot_net_RPG.Models;
using Models;

namespace Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register (User user, string password);

        Task<ServiceResponse<string>> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}