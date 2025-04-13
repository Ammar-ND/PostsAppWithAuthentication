using PostsApp.Domain_Layer.Entities;
using PostsApp.Domain_Layer.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Mohamed", Email = "mohamed@example.com", Password = "1234" },
        new User { Id = 2, Name = "Ammar", Email = "ammar@example.com", Password = "abcd" }
    };

    public User? GetUserByEmailAndPassword(string email, string password)
    {
        return _users.FirstOrDefault(u =>
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);
    }
}
