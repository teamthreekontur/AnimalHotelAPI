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
        public UserCreateInfo(string login, string password)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Passwod = password ?? throw new ArgumentNullException(nameof(password));
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Passwod { get; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; }
    }
}
