using PostsApp.Domain_Layer.Entities;

namespace PostsApp.Application_Layer.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
