using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User.Repository
{
    public class DbUserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> users;

        public DbUserRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AnimalHotel");
            users = database.GetCollection<User>("Users");
        }

        public User Create(UserCreateInfo createInfo)
        {
            if (createInfo == null)
            {
                throw new ArgumentNullException(nameof(createInfo));
            }
            if (users.Find(x=>x.Login == createInfo.Login).Any())
            {
                throw new UserDuplicationException(createInfo.Login);
            }
            var id = Guid.NewGuid();
            var user = new User
            {
                Id = id,
                Login = createInfo.Login,
                PasswordHash = Helper.Hash(createInfo.Password),
                Role = createInfo.Role
            };

            users.InsertOne(user);
            return user;
        }

        public User Get(Guid userId)
        {
            var searchResult = users.Find(x => x.Id == userId);
            if (!searchResult.Any())
            {
                throw new UserNotFoundException(userId);
            }
            return searchResult.First();
        }

        public User Get(string login)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }
            var searchResult = users.Find(x => x.Login == login);
            if (!searchResult.Any())
            {
                throw new UserNotFoundException(login);
            }
            return searchResult.First();
        }

        public User Patch(UserPatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                throw new ArgumentNullException(nameof(patchInfo));
            }
            var user = Get(patchInfo.UserId);
            if (patchInfo.Login != null)
            {
                user.Login = patchInfo.Login;
            }
            if (patchInfo.Password != null)
            {
                user.PasswordHash = Helper.Hash(patchInfo.Password);
            }
            if (patchInfo.Role != null)
            {
                user.Role = patchInfo.Role;
            }
            users.ReplaceOne(x => x.Id == user.Id, user);
            return user;
        }

        public User Remove(Guid userId)
        {
            var user = Get(userId);
            users.DeleteOne(x => x.Id == userId);
            return user;
        }
    }
}
