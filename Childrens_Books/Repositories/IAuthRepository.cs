using KidsBooks.Models;
using System.Threading.Tasks;

namespace KidsBooks.Repositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);
        Task<string> GenerateJwtTokenAsync(User user);
        Task RegisterAsync(User user);
        Task<User> AuthenticateAsync(string UserName, string password);
    }
}
