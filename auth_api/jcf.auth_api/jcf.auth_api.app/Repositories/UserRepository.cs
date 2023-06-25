using jcf.auth_api.app.Models;

namespace jcf.auth_api.app.Repositories
{
    public class UserRepository
    {
        public static User? Get(string userName, string password)
        {
            var users = new List<User>
            {
                new User { Id = Guid.Parse("606c8a80-6fd1-416b-85bd-2d2879ed0851"), UserName = "joao", Password = "joao", Role="admin" },
                new User { Id = Guid.Parse("eb391020-ac7b-4e8f-911c-cc925e3aefa2"), UserName = "anacristina", Password="anacristina", Role="basic" },
                new User { Id = Guid.Parse("9adac978-1ea7-4ce6-90ca-59e2888e2d7f"), UserName = "anamaria", Password="anamaria", Role="basic" }
            };

            return users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
