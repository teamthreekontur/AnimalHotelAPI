using System;
using System.Collections.Generic;

namespace Models.User.Repository
{
    /// <summary>
    /// Хранилище пользователей в памяти
    /// </summary>
    public class MemoryUserRepository : IUserRepository
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
                PasswordHash = Helper.Hash(createInfo.Password),
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

        /// <summary>
        /// Изменить пользователя
        /// </summary>
        /// <param name="patchInfo">Описание изменений пользователя</param>
        /// <returns>Измененный пользователь</returns>
        public User Patch(UserPatchInfo patchInfo)
        {
            if (patchInfo == null)
            {
                throw new ArgumentNullException(nameof(patchInfo));
            }

            if (!this.primaryKeyIndex.TryGetValue(patchInfo.UserId, out var user))
            {
                throw new UserNotFoundException(patchInfo.UserId);
            }

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

            return user;
        }

        public User Remove(Guid userId)
        {
            var user = Get(userId);
            primaryKeyIndex.Remove(userId);
            loginIndex.Remove(user.Login);

            return user;
        }
    }
}
