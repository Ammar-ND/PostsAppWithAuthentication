
using PostsApp.Domain_Layer.Entities;

namespace PostsApp.Application_Layer.Services.Auth
{
    public interface IAuthService
    {
        User? Login(string email, string password);
    }
}