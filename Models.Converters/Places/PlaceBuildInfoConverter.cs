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
        public static Model.PlaceCreateInfo Convert(Guid clientUserId, Client.PlaceBuildInfo clientBuildInfo)
        {

            if (clientBuildInfo == null)
            {
                throw new ArgumentNullException(nameof(clientBuildInfo));
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
