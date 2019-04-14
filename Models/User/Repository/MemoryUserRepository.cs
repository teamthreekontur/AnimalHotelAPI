using System;
using System.Collections.Generic;

namespace Models.User.Repository
{
    /// <summary>
    /// Хранилище пользователей в памяти
    /// 
    /// Потоконебезопасно
    /// </summary>
    class MemoryUserRepository : IUserRepository
    {
        private readonly Dictionary<Guid, User> primaryKeyIndex;
        private readonly Dictionary<string, User> loginIndex;

        /// <summary>
        /// Создает новый экземпляр хранилища пользователей в памяти
        /// </summary>
        public MemoryUserRepository()
        {
            primaryKeyIndex = new Dictionary<Guid, User>();
            loginIndex = new Dictionary<string, User>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="creationInfo">Информация для создания пользователя</param>
        /// <returns>Результат выполнения операции - информация о созданном пользователе</returns>
        public User Create(UserCreateInfo createInfo)
        {
            if (createInfo == null)
            {
                throw new ArgumentNullException(nameof(createInfo));
            }

            if (loginIndex.ContainsKey(createInfo.Login))
            {
                throw new UserDuplicationException(createInfo.Login);
            }

            var id = Guid.NewGuid();

            var user = new User
            {
                Id = id,
                Login = createInfo.Login,
                Password = createInfo.Passwod,
                Role = createInfo.Role
            };

            primaryKeyIndex.Add(id, user);
            loginIndex.Add(user.Login, user);

            return user;
        }

        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        public User Get(Guid userId)
        {
            if (!primaryKeyIndex.TryGetValue(userId, out var user))
            {
                throw new UserNotFoundException(userId);
            }

            return user;
        }

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Пользователь</returns>
        public User Get(string login)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (!loginIndex.TryGetValue(login, out var user))
            {
                throw new UserNotFoundException(login);
            }

            return user;
        }


        public User Patch(UserPatchInfo patchInfo)
        {
            throw new NotImplementedException();
        }
    }
}
