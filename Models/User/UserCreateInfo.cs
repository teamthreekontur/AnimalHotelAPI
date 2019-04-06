using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    /// <summary>
    /// Информация для создания пользователя
    /// </summary>
    public class UserCreateInfo
    {
        /// <summary>
        /// Инийиализирует новый экземпляр описания для создания пользователя
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Хэш пароля</param>
        public UserCreateInfo(string login, string password)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            this.Login = login;
            this.Passwod = password;
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Passwod { get; }
    }
}
