using PostsApp.Domain_Layer.Entities;
using PostsApp.Domain_Layer.Interfaces;

namespace PostsApp.Application_Layer.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Login(string email, string password)
        {
            return _userRepository.GetUserByEmailAndPassword(email, password);
        }
    }
}
