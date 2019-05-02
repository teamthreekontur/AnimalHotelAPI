using System;

namespace Models.User
{
    /// <summary>
    /// Информация для создания пользователя
    /// </summary>
    public class UserCreateInfo
    {
        /// <summary>
        /// Инициализирует новый экземпляр описания для создания пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="role">Роль</param>
        public UserCreateInfo(string login, string password, string role)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; }
    }
}
