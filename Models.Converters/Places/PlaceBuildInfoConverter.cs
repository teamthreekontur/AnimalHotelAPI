namespace Models.Converters.Places
{
    using System;
    using Client = Client.Models.Place;
    using Model = Models.Place;

    /// <summary>
    /// Предоставляет методы конвертирования запроса на создание передержки между клиентской и серверной моделями
    /// </summary>
    public static class PlaceBuildInfoConverter
    {
        /// <summary>
        /// Переводит запрос на создание передержки из клиентсокой модели в серверную
        /// </summary>
        /// <param name="clientUserId">Идентификатор пользователя в клиентской модели</param>
        /// <param name="clientBuildInfo">Запрос на создание передержки в клиентской модели</param>
        /// <returns>Запрос на создание передержки в серверной модели</returns>
        public static Model.PlaceCreateInfo Convert(string clientUserId, Client.PlaceBuildInfo clientBuildInfo)
        {
            if (clientUserId == null)
            {
                throw new ArgumentNullException(nameof(clientUserId));
            }

            if (clientBuildInfo == null)
            {
                throw new ArgumentNullException(nameof(clientBuildInfo));
            }

            if (!Guid.TryParse(clientUserId, out var modelUserId))
            {
                throw new ArgumentException($"The client user id \"{clientUserId}\" is invalid.", nameof(clientUserId));
            }



            var modelCreationInfo = new Model.PlaceCreateInfo(
                clientBuildInfo.Name,
                clientBuildInfo.Address,
                clientBuildInfo.Description,
                clientBuildInfo.Price,
                clientUserId
                );

            return modelCreationInfo;
        }
    }
}
