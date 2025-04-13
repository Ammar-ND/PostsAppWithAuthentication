using PostsApp.Domain_Layer.Entities;

namespace PostsApp.Domain_Layer.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByEmailAndPassword(string email, string password);
    }
}