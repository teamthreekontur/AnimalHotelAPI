namespace Models.Converters.Users
{
    using System;
    using Client = Client.Models.User;
    using Model = User;

    /// <summary>
    /// Предоставляет методы конвертирования пользователя между серверной и клиентской моделями
    /// </summary>
    public static class UserConverter
    {
        /// <summary>
        /// Переводит подьзователя из серверной модели в клиентскую
        /// </summary>
        /// <param name="modelUser">Пользователь в серверной модели</param>
        /// <returns>Пользователь в клиентской модели</returns>
        public static Client.User Convert(Model.User modelUser)
        {
            if (modelUser == null)
            {
                throw new ArgumentNullException(nameof(modelUser));
            }

            var clientUser = new Client.User
            {
                Id = modelUser.Id.ToString(),
                Login = modelUser.Login
            };

            return clientUser;
        }

        public static Model.UserCreateInfo Convert(Client.UserRegistrationInfo userRegistrationInfo)
        {
            if (userRegistrationInfo == null)
            {
                throw new ArgumentNullException(nameof(userRegistrationInfo));
            }

            return new Model.UserCreateInfo(
                userRegistrationInfo.Login,
                userRegistrationInfo.Password,
                "user");
        }
    }
}
