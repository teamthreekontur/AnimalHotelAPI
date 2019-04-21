using System;

namespace Models.User
{
    /// <summary>
    /// Информация для изменения пользователя
    /// </summary>
    public class UserPatchInfo
    {
        /// <summary>
        /// Создает новый экземпляр объекта, описывающего изменение пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, которого нужно изменить</param>
        /// <param name="login">Новый логин пользователя</param>
        /// <param name="password">Новый пароль пользователя</param>
        /// <param name="role">Новая роль пользователя</param>
        public UserPatchInfo(Guid userId, string login = null, string password = null, string role = null)
        {
            UserId = userId;
            Login = login;
            Password = password;
            Role = role;
        }

        /// <summary>
        /// Идентификатор пользователя, которого нужно изменить
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Новый логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Новый пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Новая роль пользователя
        /// </summary>
        public string Role { get; set; }
    }
}