using System.Threading.Tasks;
using Authentication_Prac.Models;

namespace Authentication_Prac.Repositories
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<UserModel> LoginAsync(LoginModel model);
    }
}
