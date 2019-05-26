using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Converters.Users
{
    using Model = User;
    using Client = Client.Models.User;

    /// <summary>
    /// Предоставляет методы конвертирования запроса на изменение пользователя между клиентской и серверной моделями
    /// </summary>
    public class UserPatchInfoConverter
    {
        /// <summary>
        /// Переводит запрос на изменение пользователя из клиентской модели в серверную
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="clientPatchInfo">Запрос на изменение пользователя в клиентской модели</param>
        /// <returns>Запрос на изменение пользователя в серверной модели</returns>
        public static Model.UserPatchInfo Convert(Guid userId, Client.UserPatchInfo clientPatchInfo)
        {
            if (clientPatchInfo == null)
            {
                throw new ArgumentNullException(nameof(clientPatchInfo));
            }

            var modelPatchInfo = new Model.UserPatchInfo(userId)
            {
                Login = clientPatchInfo.Login,
                Password = clientPatchInfo.Password,
                Role = "user"
            };

            return modelPatchInfo;
        }
    }
}
