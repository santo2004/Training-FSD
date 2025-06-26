using Authentication_Prac.Models;
using Authentication_Prac.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Authentication_Prac.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            JwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return "User already exists!";

            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = System.Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return string.Join(" | ", result.Errors.Select(e => e.Description));

            return "User registered successfully!";
        }

        public async Task<UserModel> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return null;

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new UserModel
            {
                Username = user.UserName,
                Email = user.Email,
                Token = token
            };
        }
    }
}
