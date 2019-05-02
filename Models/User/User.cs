using System;

namespace Models.User
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }
    }
}
